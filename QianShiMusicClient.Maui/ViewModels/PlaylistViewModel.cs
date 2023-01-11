using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi.Models;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class PlaylistViewModel : ViewModelBase
{
    [ObservableProperty]
    int _currentTypeIndex;

    public PlaylistViewModel()
    {
        
    }
}

