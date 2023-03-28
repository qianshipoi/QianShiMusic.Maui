using CommunityToolkit.Maui.Views;

using Microsoft.Extensions.Logging;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Models;

using Plugin.Maui.Audio;

using QianShiMusic.IServices;
using QianShiMusic.Models;

namespace QianShiMusic.Models
{
    public enum RepeatMode
    {
        On,
        Off,
        One
    }

    public record PlaylistSource(string Type, long Id);

    public enum UNPLAYABLE_CONDITION
    {
        PLAY_PREV_TRACK,
        PLAY_NEXT_TRACK
    }

    public interface ITrackService
    {
        Task<ITrack?> GetTrackDetailAsync(long trackId);

        Task<string?> GetTrackUrlAsync(long trackId);

        Task<IList<ITrack>?> GetPersonalFMTrackAsync();
        Task<IList<Song>?> GetPlaylistTracksAsync(long id);
    }

    public class NeteaseTrackService : ITrackService
    {
        private readonly IMusicService _musicService;
        private readonly INotificationService _notificationService;
        private readonly ILogger<NeteaseTrackService> _logger;

        public NeteaseTrackService(IMusicService musicService, INotificationService notificationService, ILogger<NeteaseTrackService> logger)
        {
            _musicService = musicService;
            _notificationService = notificationService;
            _logger = logger;
        }

        public Task<IList<ITrack>?> GetPersonalFMTrackAsync()
        {
            return CatchNotificationAsync<IList<ITrack>>(async () => {
                var response = await _musicService.PersonalFm();
                return response.Data.OfType<ITrack>().ToList();
            });
        }

        public Task<IList<Song>?> GetPlaylistTracksAsync(long id)
        {
            return CatchNotificationAsync<IList<Song>>(async () => {
                var response = await _musicService.PlaylistDetail(new NeteaseCloudMusicApi.Requests.PlaylistdetailRequest(id));
                return response.Playlist.Tracks;
            });
        }

        private async Task<T?> CatchNotificationAsync<T>(Func<Task<T?>> func)
        {
            try
            {
                return await func.Invoke();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await _notificationService.Show(ex.Message);
                return default;
            }
        }

        public Task<ITrack?> GetTrackDetailAsync(long trackId)
        {
            return CatchNotificationAsync<ITrack?>(async () => {
                var response = await _musicService.SongDetail(new NeteaseCloudMusicApi.Requests.SongDetailRequest(trackId.ToString()));
                return response.Songs.FirstOrDefault();
            });
        }

        public Task<string?> GetTrackUrlAsync(long trackId)
        {
            return CatchNotificationAsync(async () => {
                var response = await _musicService.SongUrl(new NeteaseCloudMusicApi.Requests.SongUrlRequest(trackId.ToString()));
                return response.Data.First().Url;
            });
        }
    }

    public class Player : IPlayer
    {
        private readonly IAudioManager _audioManager;
        private readonly ITrackService _trackService;

        private IAudioPlayer? _player;

        private double _progress = 0;
        private bool _playing = false;
        private bool _enabled = false;
        private RepeatMode _repeatMode = RepeatMode.Off;
        private double _volume = 1;
        private double _volumeBeforeMuted = 1;
        private bool _personalFMLoading = false;
        private bool _presonalFMNextLoading = false;

        private IList<long> _list = new List<long>();

        private PlaylistSource _playlistSource = new PlaylistSource("ablum", 0);
        private ITrack? _currentTrack;
        private IList<long> _playNextList = new List<long>();
        private bool _isPersonalFM = false;
        private ITrack? _personalFMTrack;
        private ITrack? _personalFMNextTrack;

        public double Volume
        {
            get => _volume;
            private set
            {
                _volume = value;
                if (_player is not null)
                {
                    _player.Volume = _volume;
                }
            }
        }
        public int Currrent
        {
            get;
            private set;
        }
        public event Action<bool>? PlayingChanged;
        public event Action<double>? ProgressChanged;

        public Player(IAudioManager audioManager, ITrackService trackService)
        {
            _audioManager = audioManager;
            _trackService = trackService;
            Init();
        }

        private void Init()
        {
            if (this._player is not null)
            {
                this._player.Volume = this.Volume;
            }

            // init FM.
            if (_personalFMTrack?.Id == 0
                || _personalFMNextTrack?.Id == 0
                || _personalFMTrack?.Id == _personalFMNextTrack?.Id)
            {
                Task.Run(async () => {
                    var tracks = await _trackService.GetPersonalFMTrackAsync();
                    _personalFMTrack = tracks[0];
                    _personalFMNextTrack = tracks[1];
                });
            }
        }

        private void SetPlaying(bool isPlaying)
        {
            var isChanged = _playing == isPlaying;
            if (isChanged)
            {
                _playing = isPlaying;
                PlayingChanged?.Invoke(isPlaying);

                if (isPlaying)
                {
                    ClearTimer();
                    _timer = new(TimeSpan.FromSeconds(1));
                    _timer.Elapsed += TimerElapesd;
                    _timer.AutoReset = true;
                    _timer.Start();
                }
                else
                {
                    ClearTimer();
                }
            }
        }

        private void ClearTimer()
        {
            if (_timer is not null)
            {
                _timer.Elapsed -= TimerElapesd;
                _timer.Dispose();
                _timer = null;
            }
        }

        private System.Timers.Timer? _timer;

        private void TimerElapesd(object? sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            var newProgress = _player?.CurrentPosition ?? 0;
            if (newProgress != _progress)
            {
                _progress = newProgress;
                ProgressChanged?.Invoke(newProgress);
            }
        }

        private (long? trackId, int) GetNextTrack()
        {
            var nextIndex = Currrent + 1;
            if (_playNextList.Count > 0)
            {
                var first = _playNextList.First();
                _playNextList.Remove(first);
                return (first, Currrent);
            }
            if (_repeatMode == RepeatMode.On)
            {
                if (_list.Count == nextIndex)
                {
                    return (_list[0], 0);
                }
            }

            if (_list.Count == nextIndex)
            {
                return (null, -1);
            }

            return (_list[nextIndex], nextIndex);
        }

        private (long? trackId, int) GetPrevTrack()
        {
            var nextIndex = Currrent - 1;

            if (_repeatMode == RepeatMode.On)
            {
                if (Currrent == 0)
                {
                    return (_list.Last(), _list.Count - 1);
                }
            }

            if (nextIndex < 0)
            {
                return (null, -1);
            }

            return (_list[nextIndex], nextIndex);

        }

        private void PlayAudioSource(string filename, bool autoplay = true)
        {
            if (_player is not null)
            {
                _player.PlaybackEnded -= PlaybackEnded;
                _player.Dispose();
                _player = null;
            }
            _player = _audioManager.CreatePlayer(filename);
            _player.PlaybackEnded += PlaybackEnded;
            _player.Volume = this.Volume;
            if (autoplay)
            {
                Play();
            }
        }

        public void PlayPersonalFM()
        {
            this._isPersonalFM = true;
            if (!this._enabled) this._enabled = true;
            if (this._currentTrack?.Id == this._personalFMTrack?.Id)
            {
                this.ReplaceCurrentTrack(this._personalFMTrack!.Id, true);
            }
            else
            {
                this.PlayOrPause();
            }
        }

        public void Play()
        {
            if (this._player?.IsPlaying ?? false) return;

            this._player?.Play();
            this.SetPlaying(true);
        }

        public void PlayOrPause()
        {
            if (_player is null)
            {
                return;
            }

            if (_player.IsPlaying)
            {
                this.Pause();
            }
            else
            {
                this.Play();
            }
        }

        public void Pause()
        {
            this._player?.Pause();
            this.SetPlaying(false);
        }

        public double Seek(double? position = null)
        {
            if (position.HasValue)
            {
                this._player?.Seek(position.Value);
            }
            return this._player?.CurrentPosition ?? 0;
        }

        public void Mute()
        {
            if (this.Volume == 0)
            {
                this.Volume = this._volumeBeforeMuted;
            }
            else
            {
                this._volumeBeforeMuted = this.Volume;
                this.Volume = 0;
            }
        }

        private void PlaybackEnded(object? sender, EventArgs e)
        {
            if (!_isPersonalFM && this._repeatMode == RepeatMode.One)
            {
                ReplaceCurrentTrack(this._currentTrack!.Id);
            }
            else
            {
                PlayNextTrack(this._isPersonalFM);
            }
        }

        private void PlayNextTrack(bool isPersonal)
        {
            if (isPersonal)
            {
                _ = this.PlayNextFMTrack();
            }
            else
            {
                this.PlayNextTrack();
            }
        }

        public async Task<bool> PlayNextFMTrack()
        {
            if (this._personalFMLoading)
            {
                return false;
            }
            this._isPersonalFM = true;

            if (this._personalFMNextTrack is null)
            {
                this._personalFMLoading = true;

                IList<ITrack>? result = null;
                var retryCount = 5;
                for (; retryCount > 0; retryCount--)
                {
                    try
                    {
                        result = await _trackService.GetPersonalFMTrackAsync();
                        if (result.Any())
                        {
                            break;
                        }
                        else if (retryCount > 0)
                        {
                            await Task.Delay(1000);
                        }
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                }
                this._personalFMLoading = false;

                if (result is null || retryCount < 0)
                {
                    // send message error.
                    return false;
                }

                this._personalFMTrack = result[0];
            }
            else
            {
                if (this._personalFMNextTrack?.Id == this._personalFMTrack?.Id)
                {
                    return false;
                }
                this._personalFMTrack = this._personalFMNextTrack;
            }
            if (this._isPersonalFM)
            {
                this.ReplaceCurrentTrack(_personalFMTrack!.Id);
            }
            this.LoadPersonalFMNextTrack();
            return true;
        }

        private (bool, ITrack?) LoadPersonalFMNextTrack()
        {
            if (this._presonalFMNextLoading)
            {
                return (false, null);
            }
            this._presonalFMNextLoading = true;

            var taskCompletionSource = new TaskCompletionSource<ITrack?>();
            Task.Run(async () => {
                try
                {
                    var tracks = await _trackService.GetPersonalFMTrackAsync();
                    taskCompletionSource.SetResult(tracks.First());
                }
                catch (System.Exception)
                {
                    taskCompletionSource.SetResult(null);
                }
            });
            var result = taskCompletionSource.Task.Result;
            if (result is null)
            {
                this._personalFMNextTrack = null;
                this._presonalFMNextLoading = false;
                return (false, null);
            }

            this._personalFMTrack = result;
            this.CacheNextTrack();
            this._presonalFMNextLoading = false;

            return (true, this._personalFMTrack);
        }

        public bool PlayNextTrack()
        {
            var (trackId, index) = this.GetNextTrack();

            if (trackId is null)
            {
                this._player?.Stop();
                this.SetPlaying(false);
                return false;
            }
            this.Currrent = index;
            this.ReplaceCurrentTrack(trackId.Value);
            return true;
        }

        private void ReplaceCurrentTrack(long id, bool autoplay = true, UNPLAYABLE_CONDITION ifUnplayableThen = UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK)
        {
            var task = new TaskCompletionSource<ITrack?>();

            Task.Run(async () => {
                var track = await _trackService.GetTrackDetailAsync(id);
                task.SetResult(track);
            });
            var track = task.Task.Result;
            if (track is not null)
            {
                this._currentTrack = track;
                ReplaceCurrentTrackAudio(track, autoplay, true, ifUnplayableThen);
            }
        }

        private bool ReplaceCurrentTrackAudio(ITrack track, bool autoplay, bool isCacheNextTrack, UNPLAYABLE_CONDITION ifUnplayableThen = UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK)
        {
            var source = GetAudioSource(track);
            if (!string.IsNullOrEmpty(source))
            {
                var replaced = false;
                if (track.Id == this._currentTrack?.Id)
                {
                    PlayAudioSource(source, autoplay);
                    replaced = true;
                }
                if (isCacheNextTrack)
                {
                    this.CacheNextTrack();
                }
                return replaced;
            }
            else
            {
                switch (ifUnplayableThen)
                {
                    case UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK:
                        PlayNextTrack(this._isPersonalFM);
                        break;
                    case UNPLAYABLE_CONDITION.PLAY_PREV_TRACK:
                        PlayPrevTrack();
                        break;
                }
                return false;
            }
        }

        private void CacheNextTrack()
        {
            var nextTrackId = this._isPersonalFM ? this._personalFMNextTrack?.Id : this.GetNextTrack().trackId;
            if (!nextTrackId.HasValue)
            {
                return;
            }
            if (_personalFMTrack?.Id == nextTrackId)
            {
                return;
            }

            Task.Run(async () => {
                var track = await _trackService.GetTrackDetailAsync(nextTrackId.Value);
                GetAudioSource(track);
            });
        }

        private bool PlayPrevTrack()
        {
            var (trackId, index) = GetPrevTrack();
            if (trackId is null) return false;
            this.Currrent = index;
            this.ReplaceCurrentTrack(trackId.Value, true, UNPLAYABLE_CONDITION.PLAY_PREV_TRACK);
            return true;
        }

        private string? GetAudioSource(ITrack track)
        {
            var taskComplationSource = new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);

            Task.Run(async () => {
                var result = await _trackService.GetTrackUrlAsync(track.Id);
                taskComplationSource.SetResult(result);
            });

            return taskComplationSource.Task.Result;
        }

        public void ReplacePlaylist(IEnumerable<long> trackIds, long sourceId, string sourceType, int? autoPlayTrackId = null)
        {
            this._isPersonalFM = false;
            if (!this._enabled) this._enabled = true;
            this._list = trackIds.ToList();
            this.Currrent = 0;
            this._playlistSource = new PlaylistSource(sourceType, sourceId);
            if (!autoPlayTrackId.HasValue)
            {
                this.ReplaceCurrentTrack(this._list.First());
            }
            else
            {
                this.Currrent = this._list.IndexOf(autoPlayTrackId.Value);
                this.ReplaceCurrentTrack(autoPlayTrackId.Value);
            }
        }

        public async Task PlayPlaylistById(long id)
        {
            var tracks = await _trackService.GetPlaylistTracksAsync(id);

            if (tracks is not null && tracks.Any())
            {
                var ids = tracks.Select(x => x.Id);
                ReplacePlaylist(ids, id, "playlist");
            }
        }
    }

    public interface IPlayer
    {
        double Volume { get; }
        int Currrent { get; }

        event Action<bool>? PlayingChanged;
        event Action<double>? ProgressChanged;

        void Mute();
        void Pause();
        void Play();
        Task<bool> PlayNextFMTrack();
        bool PlayNextTrack();
        void PlayOrPause();
        void PlayPersonalFM();
        Task PlayPlaylistById(long id);
        void ReplacePlaylist(IEnumerable<long> trackIds, long sourceId, string sourceType, int? autoPlayTrackId = null);
        double Seek(double? position = null);
    }

    public class MediaElementPlayer : IPlayer
    {
        private readonly ITrackService _trackService;

        private MediaElement _player;
        private System.Timers.Timer? _timer;

        private double _progress = 0;
        private bool _playing = false;
        private bool _enabled = false;
        private RepeatMode _repeatMode = RepeatMode.Off;
        private double _volume = 1;
        private double _volumeBeforeMuted = 1;
        private bool _personalFMLoading = false;
        private bool _presonalFMNextLoading = false;

        private IList<long> _list = new List<long>();

        private PlaylistSource _playlistSource = new PlaylistSource("ablum", 0);
        private ITrack? _currentTrack;
        private IList<long> _playNextList = new List<long>();
        private bool _isPersonalFM = false;
        private ITrack? _personalFMTrack;
        private ITrack? _personalFMNextTrack;

        public double Volume
        {
            get => _volume;
            private set
            {
                _volume = value;
                _player.Volume = _volume;
            }
        }
        public int Currrent
        {
            get;
            private set;
        }
        public event Action<bool>? PlayingChanged;
        public event Action<double>? ProgressChanged;

        public MediaElementPlayer(ITrackService trackService)
        {
            _trackService = trackService;
            _player = new MediaElement();
            _player.MediaEnded += PlaybackEnded;
            _player.Volume = this.Volume;

            _player.MediaFailed += (s, e) => {

            };
            _player.MediaEnded += (s, e) => {

            };
            _player.MediaOpened += (s, e) => {

            };
            Init();
        }

        private void Init()
        {
            if (this._player is not null)
            {
                this._player.Volume = this.Volume;
            }

            // init FM.
            if (_personalFMTrack?.Id == 0
                || _personalFMNextTrack?.Id == 0
                || _personalFMTrack?.Id == _personalFMNextTrack?.Id)
            {
                Task.Run(async () => {
                    var tracks = await _trackService.GetPersonalFMTrackAsync();
                    _personalFMTrack = tracks[0];
                    _personalFMNextTrack = tracks[1];
                });
            }
        }

        private void SetPlaying(bool isPlaying)
        {
            var isChanged = _playing == isPlaying;
            if (isChanged)
            {
                _playing = isPlaying;
                PlayingChanged?.Invoke(isPlaying);

                if (isPlaying)
                {
                    ClearTimer();
                    _timer = new(TimeSpan.FromSeconds(1));
                    _timer.Elapsed += TimerElapesd;
                    _timer.AutoReset = true;
                    _timer.Start();
                }
                else
                {
                    ClearTimer();
                }
            }
        }

        private void ClearTimer()
        {
            if (_timer is not null)
            {
                _timer.Elapsed -= TimerElapesd;
                _timer.Dispose();
                _timer = null;
            }
        }

        private void TimerElapesd(object? sender, EventArgs e)
        {
            UpdateProgress();
        }

        private void UpdateProgress()
        {
            var newProgress = _player?.Position.TotalSeconds ?? 0;
            if (newProgress != _progress)
            {
                _progress = newProgress;
                ProgressChanged?.Invoke(newProgress);
            }
        }

        private (long? trackId, int) GetNextTrack()
        {
            var nextIndex = Currrent + 1;
            if (_playNextList.Count > 0)
            {
                var first = _playNextList.First();
                _playNextList.Remove(first);
                return (first, Currrent);
            }
            if (_repeatMode == RepeatMode.On)
            {
                if (_list.Count == nextIndex)
                {
                    return (_list[0], 0);
                }
            }

            if (_list.Count == nextIndex)
            {
                return (null, -1);
            }

            return (_list[nextIndex], nextIndex);
        }

        private (long? trackId, int) GetPrevTrack()
        {
            var nextIndex = Currrent - 1;

            if (_repeatMode == RepeatMode.On)
            {
                if (Currrent == 0)
                {
                    return (_list.Last(), _list.Count - 1);
                }
            }

            if (nextIndex < 0)
            {
                return (null, -1);
            }

            return (_list[nextIndex], nextIndex);

        }

        private void PlayAudioSource(string source, bool autoplay = true)
        {
            _player.Source = MediaSource.FromUri(source);

            if (autoplay)
            {
                Play();
            }
        }

        public void PlayPersonalFM()
        {
            this._isPersonalFM = true;
            if (!this._enabled) this._enabled = true;
            if (this._currentTrack?.Id == this._personalFMTrack?.Id)
            {
                this.ReplaceCurrentTrack(this._personalFMTrack!.Id, true);
            }
            else
            {
                this.PlayOrPause();
            }
        }

        public void Play()
        {
            if (this._player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing) return;

            this._player.Play();
            this.SetPlaying(true);
        }

        public void PlayOrPause()
        {
            if (_player is null)
            {
                return;
            }

            if (_player.CurrentState == CommunityToolkit.Maui.Core.Primitives.MediaElementState.Playing)
            {
                this.Pause();
            }
            else
            {
                this.Play();
            }
        }

        public void Pause()
        {
            this._player?.Pause();
            this.SetPlaying(false);
        }

        public double Seek(double? position = null)
        {
            if (position.HasValue)
            {
                this._player?.SeekTo(TimeSpan.FromSeconds(position.Value));
            }
            return this._player?.Position.TotalSeconds ?? 0;
        }

        public void Mute()
        {
            if (this.Volume == 0)
            {
                this.Volume = this._volumeBeforeMuted;
            }
            else
            {
                this._volumeBeforeMuted = this.Volume;
                this.Volume = 0;
            }
        }

        private void PlaybackEnded(object? sender, EventArgs e)
        {
            if (!_isPersonalFM && this._repeatMode == RepeatMode.One)
            {
                ReplaceCurrentTrack(this._currentTrack!.Id);
            }
            else
            {
                PlayNextTrack(this._isPersonalFM);
            }
        }

        private void PlayNextTrack(bool isPersonal)
        {
            if (isPersonal)
            {
                _ = this.PlayNextFMTrack();
            }
            else
            {
                this.PlayNextTrack();
            }
        }

        public async Task<bool> PlayNextFMTrack()
        {
            if (this._personalFMLoading)
            {
                return false;
            }
            this._isPersonalFM = true;

            if (this._personalFMNextTrack is null)
            {
                this._personalFMLoading = true;

                IList<ITrack>? result = null;
                var retryCount = 5;
                for (; retryCount > 0; retryCount--)
                {
                    try
                    {
                        result = await _trackService.GetPersonalFMTrackAsync();
                        if (result.Any())
                        {
                            break;
                        }
                        else if (retryCount > 0)
                        {
                            await Task.Delay(1000);
                        }
                    }
                    catch (System.Exception)
                    {
                        break;
                    }
                }
                this._personalFMLoading = false;

                if (result is null || retryCount < 0)
                {
                    // send message error.
                    return false;
                }

                this._personalFMTrack = result[0];
            }
            else
            {
                if (this._personalFMNextTrack?.Id == this._personalFMTrack?.Id)
                {
                    return false;
                }
                this._personalFMTrack = this._personalFMNextTrack;
            }
            if (this._isPersonalFM)
            {
                this.ReplaceCurrentTrack(_personalFMTrack!.Id);
            }
            this.LoadPersonalFMNextTrack();
            return true;
        }

        private (bool, ITrack?) LoadPersonalFMNextTrack()
        {
            if (this._presonalFMNextLoading)
            {
                return (false, null);
            }
            this._presonalFMNextLoading = true;

            var taskCompletionSource = new TaskCompletionSource<ITrack?>();
            Task.Run(async () => {
                try
                {
                    var tracks = await _trackService.GetPersonalFMTrackAsync();
                    taskCompletionSource.SetResult(tracks.First());
                }
                catch (System.Exception)
                {
                    taskCompletionSource.SetResult(null);
                }
            });
            var result = taskCompletionSource.Task.Result;
            if (result is null)
            {
                this._personalFMNextTrack = null;
                this._presonalFMNextLoading = false;
                return (false, null);
            }

            this._personalFMTrack = result;
            this.CacheNextTrack();
            this._presonalFMNextLoading = false;

            return (true, this._personalFMTrack);
        }

        public bool PlayNextTrack()
        {
            var (trackId, index) = this.GetNextTrack();

            if (trackId is null)
            {
                this._player?.Stop();
                this.SetPlaying(false);
                return false;
            }
            this.Currrent = index;
            this.ReplaceCurrentTrack(trackId.Value);
            return true;
        }

        private void ReplaceCurrentTrack(long id, bool autoplay = true, UNPLAYABLE_CONDITION ifUnplayableThen = UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK)
        {
            var task = new TaskCompletionSource<ITrack?>();

            Task.Run(async () => {
                var track = await _trackService.GetTrackDetailAsync(id);
                task.SetResult(track);
            });
            var track = task.Task.Result;
            if (track is not null)
            {
                this._currentTrack = track;
                ReplaceCurrentTrackAudio(track, autoplay, true, ifUnplayableThen);
            }
        }

        private bool ReplaceCurrentTrackAudio(ITrack track, bool autoplay, bool isCacheNextTrack, UNPLAYABLE_CONDITION ifUnplayableThen = UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK)
        {
            var source = GetAudioSource(track);
            if (!string.IsNullOrEmpty(source))
            {
                var replaced = false;
                if (track.Id == this._currentTrack?.Id)
                {
                    PlayAudioSource(source, autoplay);
                    replaced = true;
                }
                if (isCacheNextTrack)
                {
                    this.CacheNextTrack();
                }
                return replaced;
            }
            else
            {
                switch (ifUnplayableThen)
                {
                    case UNPLAYABLE_CONDITION.PLAY_NEXT_TRACK:
                        PlayNextTrack(this._isPersonalFM);
                        break;
                    case UNPLAYABLE_CONDITION.PLAY_PREV_TRACK:
                        PlayPrevTrack();
                        break;
                }
                return false;
            }
        }

        private void CacheNextTrack()
        {
            var nextTrackId = this._isPersonalFM ? this._personalFMNextTrack?.Id : this.GetNextTrack().trackId;
            if (!nextTrackId.HasValue)
            {
                return;
            }
            if (_personalFMTrack?.Id == nextTrackId)
            {
                return;
            }

            Task.Run(async () => {
                var track = await _trackService.GetTrackDetailAsync(nextTrackId.Value);
                GetAudioSource(track);
            });
        }

        private bool PlayPrevTrack()
        {
            var (trackId, index) = GetPrevTrack();
            if (trackId is null) return false;
            this.Currrent = index;
            this.ReplaceCurrentTrack(trackId.Value, true, UNPLAYABLE_CONDITION.PLAY_PREV_TRACK);
            return true;
        }

        private string? GetAudioSource(ITrack track)
        {
            var taskComplationSource = new TaskCompletionSource<string?>(TaskCreationOptions.RunContinuationsAsynchronously);

            Task.Run(async () => {
                var result = await _trackService.GetTrackUrlAsync(track.Id);
                taskComplationSource.SetResult(result);
            });

            return taskComplationSource.Task.Result;
        }

        public void ReplacePlaylist(IEnumerable<long> trackIds, long sourceId, string sourceType, int? autoPlayTrackId = null)
        {
            this._isPersonalFM = false;
            if (!this._enabled) this._enabled = true;
            this._list = trackIds.ToList();
            this.Currrent = 0;
            this._playlistSource = new PlaylistSource(sourceType, sourceId);
            if (!autoPlayTrackId.HasValue)
            {
                this.ReplaceCurrentTrack(this._list.First());
            }
            else
            {
                this.Currrent = this._list.IndexOf(autoPlayTrackId.Value);
                this.ReplaceCurrentTrack(autoPlayTrackId.Value);
            }
        }

        public async Task PlayPlaylistById(long id)
        {
            var tracks = await _trackService.GetPlaylistTracksAsync(id);

            if (tracks is not null && tracks.Any())
            {
                var ids = tracks.Select(x => x.Id);
                ReplacePlaylist(ids, id, "playlist");
            }
        }
    }
}
