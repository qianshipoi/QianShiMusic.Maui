using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Services;

namespace QianShiMusicClient.Maui.ViewModels.Login;

public sealed partial class LoginSelectionViewModel : ViewModelBase
{
    private readonly INavigationService _navigationService;
    public LoginSelectionViewModel()
    {
        _navigationService = ServiceHelper.GetRequiredService<INavigationService>();
    }

    [RelayCommand]
    Task GoToLoginByEmailPage() => _navigationService.GoToLoginByEmailPageAsync();


    [RelayCommand]
    Task GoToLoginByPhonePage() => _navigationService.GoToLoginByPhonePageAsync();
}
