using CommunityToolkit.Maui.Alerts;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Models.Responses;

using System.Net.Http.Json;

namespace QianShiMusicClient.Maui.Services;

public class LoginService : ILoginService
{
    public bool IsLoggedIn { get; private set; }

    public string? Cookie { get; private set; }

    private async Task<bool> HandleLoginAsync(LoginResponse? response)
    {
        if (response == null)
        {
            await Toast.Make("网络异常").Show();
            return false;
        }
        if (response.Code != 200)
        {
            await Toast.Make(response.Msg).Show();
            return false;
        }

        Cookie = response.Cookie;
        IsLoggedIn = true;
        return true;
    }

    public async Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(AppConsts.MusicApiBaseUrl);
        var response = await client.GetFromJsonAsync<LoginResponse>($"/login/cellphone?phone={phoneNumber}&md5_password={password.ToMd5()}&t={DateTime.Now.Ticks}", cancellationToken);
        return await HandleLoginAsync(response);
    }

    public async Task<bool> PhoneCaptchaLoginAsync(string phoneNumber, string captcha, CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(AppConsts.MusicApiBaseUrl);
        var response = await client.GetFromJsonAsync<LoginResponse>($"/login/cellphone?phone={phoneNumber}&captcha={captcha}&t={DateTime.Now.Ticks}", cancellationToken);
        return await HandleLoginAsync(response);
    }

    public async Task<bool> EmailLoginAsync(string email, string password, CancellationToken cancellationToken = default)
    {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(AppConsts.MusicApiBaseUrl);
        var response = await client.GetFromJsonAsync<LoginResponse>($"/login?email={email}&md5_password={password}&t={DateTime.Now.Ticks}", cancellationToken);
        return await HandleLoginAsync(response);
    }
}

public interface ILoginService
{
    bool IsLoggedIn { get; }
    string? Cookie { get; }

    Task<bool> EmailLoginAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<bool> PhoneCaptchaLoginAsync(string phoneNumber, string captcha, CancellationToken cancellationToken = default);
    Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default);
}
