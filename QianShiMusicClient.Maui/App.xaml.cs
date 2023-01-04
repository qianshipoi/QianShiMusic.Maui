using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Views;

namespace QianShiMusicClient.Maui;

public partial class App : Application
{
    public static new App Current => (App)Application.Current!;

    public App()
    {
        InitializeComponent();
        //MainPage = ServiceHelper.GetRequiredService<AppShell>();
        MainPage = ServiceHelper.GetRequiredService<SplashScreenPage>();
    }
}
