using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Models;

using QianShiMusic.IServices;

namespace QianShiMusic.ViewModels
{
    public partial class PlaylistDetailViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IMusicService _musicService;
        private readonly INotificationService _notificationService;

        [ObservableProperty]
        private Playlist? _playlistDetail;

        public PlaylistDetailViewModel(IMusicService musicService, INotificationService notificationService)
        {
            _musicService = musicService;
            _notificationService = notificationService;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var result = long.TryParse(query["Id"]?.ToString(), out var id);
            if (result)
            {
                _ = GetDetailAsync(id);
            }
        }

        public async Task GetDetailAsync(long id)
        {
            IsBusy = true;
            try
            {
                var response = await _musicService.PlaylistDetail(new NeteaseCloudMusicApi.Requests.PlaylistdetailRequest(id));
                if (response.Code != 200)
                {
                    await _notificationService.Show(response.Msg ?? response.Message ?? "获取歌单详情失败！");
                    return;
                }

                PlaylistDetail = response.Playlist;
            }
            catch (Exception ex)
            {
                await _notificationService.Show(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
