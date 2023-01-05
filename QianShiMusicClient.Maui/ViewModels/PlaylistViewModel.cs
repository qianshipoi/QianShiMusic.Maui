using CommunityToolkit.Mvvm.ComponentModel;

using NeteaseCloudMusicApi.Models;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class PlaylistViewModel : ViewModelBase
{
    [ObservableProperty]
    Playlist _playlist;

    public ObservableCollection<Song> Songs { get; private set; }

    public PlaylistViewModel()
    {
        
    }
}

