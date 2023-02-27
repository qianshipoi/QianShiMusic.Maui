using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Models;

using QianShiMusic.IServices;

using System.Collections.ObjectModel;

namespace QianShiMusic.ViewModels
{
    public partial class PlaylistDetailViewModel : BaseViewModel, IQueryAttributable
    {
        private readonly IMusicService _musicService;
        private readonly INotificationService _notificationService;
        private readonly IDispatcher _dispatcher;

        private const int Limit = 30;
        private int _offset = 0;

        public ObservableCollection<Song> Songs { get; private set; }

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(RefreshCommand))]
        private Playlist? _playlistDetail;

        partial void OnPlaylistDetailChanged(Playlist? value)
        {
            if (value is null)
            {
                HasMore = false;
            }
            else
            {
                HasMore = value.TrackCount > _offset;
            }
        }

        [ObservableProperty]
        private bool _hasMore;

        public PlaylistDetailViewModel(IMusicService musicService, INotificationService notificationService, IDispatcher dispatcher)
        {
            _musicService = musicService;
            _notificationService = notificationService;
            Songs = new ObservableCollection<Song>();
            _dispatcher = dispatcher;
        }

        public void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            var result = long.TryParse(query["Id"]?.ToString(), out var id);

            if (!result)
            {
                Shell.Current.Navigation.PopAsync();
                return;
            }

            Task.Run(async () => {
                await GetDetailAsync(id);
                await Refresh();
            });
        }

        private async Task LoadingHandleAsync(Func<Task> task)
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            try
            {
                await task.Invoke();
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

        private async Task GetDetailAsync(long id)
        {
            await LoadingHandleAsync(async () => {
                var response = await _musicService.PlaylistDetail(new NeteaseCloudMusicApi.Requests.PlaylistdetailRequest(id));
                if (response.Code != 200)
                {
                    await _notificationService.Show(response.Msg ?? response.Message ?? "获取歌单详情失败！");
                    return;
                }

                await _dispatcher.DispatchAsync(() => {
                    PlaylistDetail = response.Playlist;
                });
            });
        }

        private bool CanRefresh()
            => PlaylistDetail != null && PlaylistDetail.TrackCount > _offset;

        [RelayCommand(CanExecute = nameof(CanRefresh))]
        private async Task Refresh()
        {

            if (PlaylistDetail is null || PlaylistDetail.Id <= 0)
            {
                return;
            }
            await LoadingHandleAsync(async () => {
                var response = await _musicService.PlaylistTrackAll(new NeteaseCloudMusicApi.Requests.PlaylistTrackAllRequest(PlaylistDetail.Id)
                {
                    Limit = Limit,
                    Offset = _offset
                });

                if (response.Code != 200)
                {
                    await _notificationService.Show(response.GetErrorMsg("获取歌单详情失败！"));
                    return;
                }

                _offset += response.Songs.Count;

                HasMore = CanRefresh();

                await _dispatcher.DispatchAsync(() => {
                    foreach (var song in response.Songs)
                    {
                        Songs.Add(song);
                    }
                });
            });
        }
    }
}
