using CommunityToolkit.Maui.Alerts;

using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Requests;
using NeteaseCloudMusicApi.Responses;

using QianShiMusicClient.Maui.Helpers;

namespace QianShiMusicClient.Maui.Services;

public class LoginService : ILoginService
{
    readonly IMusicService _musicService;

    public bool IsLoggedIn { get; private set; }

    public string? Cookie { get; private set; }

    public LoginService(IMusicService musicService)
    {
        _musicService = musicService;
    }

    private async Task<bool> HandleLoginAsync(LoginResponse? response)
    {
        if (response == null)
        {
            await Toast.Make("网络异常").Show();
            return false;
        }
        if (response.Code != 200)
        {
            await Toast.Make(response.Msg ?? "账号或密码错误").Show();
            return false;
        }

        Preferences.Set("cookie", ApiClient.GetCookieString());
        Cookie = response.Cookie;
        IsLoggedIn = true;
        return true;
    }

    public async Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default)
    {
        var response = await _musicService.LoginCellphone(new LoginCellphoneRequest(phoneNumber) { Md5Password = password.ToMd5().ToLower(), Time = DateTime.Now.Ticks }, cancellationToken);
        return await HandleLoginAsync(response);
    }

    public async Task<bool> CaptchaSentAsync(string phoneNumber, CancellationToken cancellationToken = default)
    {
        var response = await _musicService.CaptchaSent(new CaptchaSentRequest(phoneNumber) { Time = DateTime.Now.Ticks }, cancellationToken);
        if (response.Code != 200)
        {
            await Toast.Make(response.Msg ?? response.Message ?? "手机号码不符合规范").Show();
            return false;
        }

        return response.Data;
    }

    public async Task<bool> PhoneCaptchaLoginAsync(string phoneNumber, string captcha, CancellationToken cancellationToken = default)
    {
        var response = await _musicService.LoginCellphone(new LoginCellphoneRequest(phoneNumber) { Captcha = captcha, Time = DateTime.Now.Ticks }, cancellationToken);
        return await HandleLoginAsync(response);
    }

    public async Task<bool> EmailLoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        var response = await _musicService.Login(new LoginRequest(email) { Md5Password = password.ToMd5().ToLower(), Time = DateTime.Now.Ticks }, cancellationToken);
        return await HandleLoginAsync(response);
    }

    public async Task<bool> LoginStatus(CancellationToken cancellationToken = default)
    {
        var response = await _musicService.LoginStatus(new BaseRequest() { Time = DateTime.Now.Ticks }, cancellationToken);
        if (response.Data.Profile is null)
        {
            await Toast.Make("登录已过期").Show();
            return false;
        }

        IsLoggedIn = true;
        return true;
    }

    public async Task<bool> Logout(CancellationToken cancellationToken = default)
    {
        var response = await _musicService.Logout(cancellationToken: cancellationToken);
        if(response.Code == 200)
        {
            Preferences.Remove("cookie");
        }
        return response.Code == 200;
    }
}
