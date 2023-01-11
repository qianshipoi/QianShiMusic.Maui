using CommunityToolkit.Maui.Extensions;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views;

public partial class HomeView : ContentView
{
	public HomeView()
	{
		InitializeComponent();
        this.BindingContext = ServiceHelper.GetRequiredService<HomeViewModel>();
        MainControl.Scrolled += MainControl_Scrolled;
    }

    private void MainControl_Scrolled(object? sender, ScrolledEventArgs e)
    {
        // 170
        var alpha = (float)e.ScrollY / 160 * 255;
        if(e.ScrollY >= 160)
        {
            alpha = 255;
        }
        HeaderControl.BackgroundColorTo(new Color(255, 255, 255, alpha));
        HeaderTitleControl.Opacity = alpha / 255;
        UserInfoControl.Opacity = 1 - HeaderTitleControl.Opacity;
    }
}