using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views.Playlists;

public partial class OfficialPlaylistView
{
    public PlaylistTypeViewModel ViewModel => (PlaylistTypeViewModel)BindingContext;

    public OfficialPlaylistView()
    {
        InitializeComponent();
    }
}