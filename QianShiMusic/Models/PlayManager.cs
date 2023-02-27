using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Models;

using Plugin.Maui.Audio;

using QianShiMusic.IServices;

using System.Collections.ObjectModel;

namespace QianShiMusic.Models
{
    public partial class PlayManager : ObservableObject
    {
        private readonly IAudioManager _audioManager;
        private readonly IMusicService _musicService;
        private readonly INotificationService _notificationService;

        private IAudioPlayer? _player;

        public ObservableCollection<Song> Songs { get; }

        [ObservableProperty]
        private Song? _current;

        partial void OnCurrentChanged(Song? value)
        {
            _player?.Dispose();
            _player = null;

            if (value is null)
            {
                return;
            }

            var url = GetSongUrl(value).Result;
            if (string.IsNullOrWhiteSpace(url))
            {
                return;
            }
            _player = _audioManager.CreatePlayer(url);
            _player.Play();
        }

        public PlayManager(IAudioManager audioManager, IMusicService musicService, INotificationService notificationService)
        {
            _audioManager = audioManager;
            Songs = new ObservableCollection<Song>();
            Songs.CollectionChanged += (s, e) => {
                NextCommand.NotifyCanExecuteChanged();
                PreviousCommand.NotifyCanExecuteChanged();
            };
            _musicService = musicService;
            _notificationService = notificationService;
        }

        [RelayCommand(CanExecute = nameof(CanNext))]
        private void Next()
        {
            if (Current is null)
            {
                Current = Songs.First();
                return;
            }

            var index = Songs.IndexOf(Current);
            if (index == -1)
            {
                Current = Songs.First();
                return;
            }

            if (index == Songs.Count - 1)
            {
                index = -1;
            }

            Current = Songs[index + 1];
        }

        private bool CanNext() => Songs.Any();

        [RelayCommand(CanExecute = nameof(CanPrevious))]
        private void Previous()
        {
            if (Current is null)
            {
                Current = Songs.Last();
                return;
            }

            var index = Songs.IndexOf(Current);
            if (index == -1 || index == 0)
            {
                Current = Songs.Last();
                return;
            }

            Current = Songs[index - 1];
        }

        private bool CanPrevious() => Songs.Any();

        private async Task<string?> GetSongUrl(Song value)
        {
            var urlResponse = await _musicService.SongUrl(new NeteaseCloudMusicApi.Requests.SongUrlRequest(value.Id.ToString()));

            if (urlResponse.Code != 200)
            {
                await _notificationService.Show(urlResponse.GetErrorMsg());
                return null;
            }

            return urlResponse.Data.FirstOrDefault()?.Url;
        }
    }
}
