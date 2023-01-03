using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Views;

namespace QianShiMusicClient.Maui;

public partial class App : Application
{
    public static new App Current => (App)Application.Current!;

    public App()
    {
        InitializeComponent();
        MainPage = new NavigationPage(ServiceHelper.GetRequiredService<LoginSelectionPage>()); //  serviceProvider.GetRequiredService<AppShell>();
    }
}
