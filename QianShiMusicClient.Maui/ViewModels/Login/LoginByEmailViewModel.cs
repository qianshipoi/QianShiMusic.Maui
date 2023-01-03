using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Services;

namespace QianShiMusicClient.Maui.ViewModels.Login;

public partial class LoginByEmailViewModel : ViewModelBase
{
    private readonly ILoginService _loginService;
    [ObservableProperty]
    private string? _emailTxt;
    [ObservableProperty]
    private string? _passwordTxt;
    private CancellationTokenSource? _loginCancellationTokenSource;

    public LoginByEmailViewModel(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [RelayCommand]
    async Task Submit()
    {
        if (string.IsNullOrWhiteSpace(EmailTxt) || string.IsNullOrWhiteSpace(PasswordTxt))
        {
            await Toast.Make("邮箱或密码不能为空").Show();
        }
        _loginCancellationTokenSource = new CancellationTokenSource();

        try
        {
            var result = await _loginService.EmailLoginAsync(EmailTxt!, PasswordTxt!, _loginCancellationTokenSource.Token);
        }
        finally
        {
            Cancel();
        }
    }

    [RelayCommand]
    void Cancel()
    {
        _loginCancellationTokenSource?.Cancel();
        _loginCancellationTokenSource?.Dispose();
        _loginCancellationTokenSource = null;
    }
}
