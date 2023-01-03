using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Services;

namespace QianShiMusicClient.Maui.ViewModels.Login;

public partial class LoginByPhoneViewModel : ObservableObject
{
    readonly ILoginService _loginService;

    [ObservableProperty]
    string? _phone;
    [ObservableProperty]
    string? _password;
    [ObservableProperty]
    string? _captcha;

    [ObservableProperty]
    int _countdown;
    [ObservableProperty]
    string _currentState = "phone";

    public LoginByPhoneViewModel(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [RelayCommand]
    void Next()
    {
        CurrentState = "captcha";
    }

    [RelayCommand]
    void PasswordLogin()
    {
        CurrentState = "password";
    }

    [RelayCommand]
    void Resend()
    {
        if(Countdown > 0)
        {
            return;
        }
        // resend..
    }
}
