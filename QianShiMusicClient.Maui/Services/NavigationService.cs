using QianShiMusicClient.Maui.Views;
using QianShiMusicClient.Maui.Views.Login;

namespace QianShiMusicClient.Maui.Services;

public class NavigationService : INavigationService
{
    private Page Page => App.Current.MainPage ?? throw new Exception("App.Current.MainPage is null.");
    private Shell Shell => Shell.Current;

    private readonly IServiceProvider _serviceProvider;
    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task GoToLoginPageAsync()
        => PushModelAsync(_serviceProvider.GetRequiredService<LoginSelectionPage>());

    public  Task GoToLoginByEmailPageAsync()
        => PushAsync(_serviceProvider.GetRequiredService<LoginByEmailPage>());

    public  Task GoToLoginByPhonePageAsync()
        => PushAsync(_serviceProvider.GetRequiredService<LoginByPhonePage>());

    public Task PushModelAsync(Page page)
        => Page.Navigation.PushModalAsync(page);

    public Task PushAsync(Page page)
        => Page.Navigation.PushAsync(page);
}
