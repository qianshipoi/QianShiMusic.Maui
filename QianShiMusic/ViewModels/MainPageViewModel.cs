using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Models;

using QianShiMusic.IServices;

using System.Collections.ObjectModel;

namespace QianShiMusic.ViewModels
{
    public partial class MainPageViewModel : BaseViewModel
    {
        private readonly IMusicService _musicService;
        private readonly INotificationService _notificationService;

        [ObservableProperty]
        private bool _more;

        private int _offset;
        private int _limit = 30;

        public ObservableCollection<Playlist> Playlists { get; }

        public MainPageViewModel(IMusicService musicService, INotificationService notificationService)
        {
            _musicService = musicService;
            _notificationService = notificationService;

            Playlists = new ObservableCollection<Playlist>();
            More = true;

            Task.Run(GetTopListAsync);
        }

        public async Task GetTopListAsync()
        {
            if (!More)
            {
                await _notificationService.Show("没有更多了！");
                return;
            }
            IsBusy = true;
            try
            {
                var response = await _musicService.TopPlaylist(new NeteaseCloudMusicApi.Requests.TopPlaylistRequest("华语")
                {
                    Limit = _limit,
                    Offset = _offset,
                });
                if (response.Code != 200)
                {
                    await _notificationService.Show(response.Msg ?? response.Message ?? "获取排行榜失败！");
                    return;
                }

                More = response.More;
                _offset += (int)response.Total;

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    foreach (var playlist in response.Playlists)
                    {
                        Playlists.Add(playlist);
                    }
                });
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
