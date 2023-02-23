using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi;

using QianShiMusic.IServices;

namespace QianShiMusic.ViewModels
{
    public partial class FoundPageViewModel : BaseViewModel
    {
        private readonly IMusicService _musicService;

        private readonly INotificationService _notificationService;

        [ObservableProperty]
        string? _searchText;

        public FoundPageViewModel(IMusicService musicService, INotificationService notificationService)
        {
            _musicService = musicService;
            _notificationService = notificationService;
        }
    }
}
