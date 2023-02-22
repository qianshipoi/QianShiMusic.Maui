using QianShiMusic.Helpers;
using QianShiMusic.IServices;

using System.ComponentModel;

namespace QianShiMusic.Views;

public partial class SplashScreenPage : ContentPage
{
	public SplashScreenPage()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        BackgroundWorker backgroundWorker = new BackgroundWorker();
        backgroundWorker.DoWork += BackgroundWorker_DoWork;
        backgroundWorker.RunWorkerAsync();
    }

    private void GoToLoginPage()
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            App.Current.MainPage = new NavigationPage(ServiceHelper.GetRequiredService<LoginPage>());
        });
    }

    private async void BackgroundWorker_DoWork(object? sender, DoWorkEventArgs e)
    {
        var cookieStr = Preferences.Get("cookie", string.Empty);
        if (!string.IsNullOrEmpty(cookieStr))
        {
            GoToLoginPage();
            return;
        }

        var isLoggedIn = await ServiceHelper.GetRequiredService<ILoginService>().LoginStatus();
        if (!isLoggedIn)
        {
            GoToLoginPage();
            return;
        }

        MainThread.BeginInvokeOnMainThread(() =>
        {
            App.Current.MainPage = ServiceHelper.GetRequiredService<AppShell>();
        });
    }
}