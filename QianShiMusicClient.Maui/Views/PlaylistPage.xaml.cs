using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views;

public partial class PlaylistPage : ContentPage
{
    public PlaylistPage()
    {
        InitializeComponent();
        this.BindingContext = ServiceHelper.GetRequiredService<PlaylistViewModel>();
    }
}