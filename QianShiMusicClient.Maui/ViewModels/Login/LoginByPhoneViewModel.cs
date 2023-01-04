using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Services;

namespace QianShiMusicClient.Maui.ViewModels.Login;

public partial class LoginByPhoneViewModel : ObservableObject
{
    readonly ILoginService _loginService;

    [ObservableProperty]
    bool _isBusy;

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
    async Task Next()
    {
        if (string.IsNullOrWhiteSpace(Phone))
        {
            await Toast.Make("请输入手机号").Show();
            return;
        }
        CurrentState = "captcha";
    }

    [RelayCommand]
    void PasswordLogin()
    {
        CurrentState = "password";
    }

    [RelayCommand(CanExecute = nameof(CanPasswordLoginSubmit))]
    async Task PasswordLoginSubmit()
    {
        if (string.IsNullOrWhiteSpace(Password))
        {
            await Toast.Make("请输入密码").Show();
            return;
        }
        IsBusy = true;
        try
        {
            var result = await _loginService.PhonePwdLoginAsync(Phone!.Trim(), Password.Trim());
            if (result)
            {
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    App.Current.MainPage = ServiceHelper.GetRequiredService<AppShell>();
                });
            }
        }
        catch (OperationCanceledException)
        {
            await Toast.Make("登录已取消").Show();
        }
        catch (Exception ex)
        {
            await Toast.Make(ex.Message).Show();
        }
        finally
        {
            IsBusy = false;
        }
    }

    bool CanPasswordLoginSubmit()
    {
        return !IsBusy;
    }


    [RelayCommand]
    void Resend()
    {
        if (Countdown > 0)
        {
            return;
        }
        // resend..
    }
}
