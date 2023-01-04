namespace QianShiMusicClient.Maui.Services;

public interface ILoginService
{
    bool IsLoggedIn { get; }
    string? Cookie { get; }

    Task<bool> EmailLoginAsync(string email, string password, CancellationToken cancellationToken = default);
    Task<bool> PhoneCaptchaLoginAsync(string phoneNumber, string captcha, CancellationToken cancellationToken = default);
    Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default);
}
