using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi;

using QianShiMusicClient.Maui.Converters;
using QianShiMusicClient.Maui.Helpers;

using Sharpnado.TaskLoaderView;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels
{
    public partial class PlaylistTypeViewModel : ObservableObject
    {
        readonly string _type;
        readonly int _limit = 20;
        readonly IMusicService _musicService;

        int _offset = 0;

        [ObservableProperty]
        bool _isBusy;

        bool _isLoaded;

        public ObservableCollection<NeteaseCloudMusicApi.Models.Playlist> Playlists { get; }

        public TaskLoaderNotifier<IReadOnlyCollection<NeteaseCloudMusicApi.Models.Playlist>> SillyPeopleLoaderNotifier { get; }

        public PlaylistTypeViewModel(string type, IMusicService musicService)
        {
            _type = type;
            _musicService = musicService;
            Playlists = new ObservableCollection<NeteaseCloudMusicApi.Models.Playlist>();
            SillyPeopleLoaderNotifier = new TaskLoaderNotifier<IReadOnlyCollection<NeteaseCloudMusicApi.Models.Playlist>>();
        }

        public async Task LoadAsync()
        {
            if (IsBusy || _isLoaded) return;
            IsBusy = true;
            try
            {
                var response = await _musicService.TopPlaylist(new NeteaseCloudMusicApi.Requests.TopPlaylistRequest(_type)
                {
                    Limit = _limit,
                    Offset = _offset,
                });

                if (response.Code != 200)
                {
                    throw new Exception(response.Msg ?? response.Message ?? "获取歌单列表异常！");
                }

                await MainThread.InvokeOnMainThreadAsync(async () =>
                {
                    foreach (var item in response.Playlists)
                    {
                        await Task.Delay(200);
                        item.CoverImgUrl = NeteaseImageResourceUrlConverter.FormatUrl(item.CoverImgUrl, "64y64");
                        Playlists.Add(item);
                    }
                });

                _isLoaded = true;
            }
            catch (Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
