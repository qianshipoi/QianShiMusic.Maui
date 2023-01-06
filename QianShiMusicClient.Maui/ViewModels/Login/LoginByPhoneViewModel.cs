using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Services;

using System.Threading;

namespace QianShiMusicClient.Maui.ViewModels.Login;

public partial class LoginByPhoneViewModel : ObservableObject
{
    readonly ILoginService _loginService;

    Timer? _timer;

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
        if (IsBusy) return;
        if (string.IsNullOrWhiteSpace(Phone))
        {
            await Toast.Make("请输入手机号").Show();
            return;
        }
        var result = await SentCaptcha();
        if (result)
        {
            CurrentState = "captcha";
        }
    }

    [RelayCommand]
    async Task Resent()
    {
        await SentCaptcha();
    }

    void ClearTimer()
    {
        _timer?.Dispose();
        _timer = null;
    }

    async Task<bool> SentCaptcha()
    {
        if (IsBusy || Countdown > 0) return false;
        IsBusy = true;

        try
        {
            var result = await _loginService.CaptchaSentAsync(Phone!.Trim());
            if (!result) return false;
            await Toast.Make("发送成功").Show();
            Countdown = 60;
            ClearTimer();
            _timer = new Timer(UpdateCountdown, null, 0, 1000);
        }
        catch (Exception ex)
        {
            await Toast.Make(ex.Message).Show();
            return false;
        }
        finally
        {
            IsBusy = false;
        }
        return true;
    }

    void UpdateCountdown(object? state)
    {
        if (Countdown > 0)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Countdown--;
            });
        }
        else
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Countdown = 0;
            });
            ClearTimer();
        }
    }

    [RelayCommand]
    async Task CaptchaLoginSubmit()
    {
        if (string.IsNullOrWhiteSpace(Captcha))
        {
            await Toast.Make("请输入验证码").Show();
            return;
        }
        IsBusy = true;
        try
        {
            var result = await _loginService.PhoneCaptchaLoginAsync(Phone!.Trim(), Captcha.Trim());
            if (result)
            {
                ClearTimer();
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
                ClearTimer();
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
}
