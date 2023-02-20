namespace QianShiMusic.IServices
{
    public interface ILoginService
    {
        bool IsLoggedIn { get; }
        string? Cookie { get; }

        Task<bool> CaptchaSentAsync(string phoneNumber, CancellationToken cancellationToken = default);
        Task<(bool result, bool update)> CheckQrCodeLogin(string key, CancellationToken cancellationToken = default);
        Task<bool> EmailLoginAsync(string email, string password, CancellationToken cancellationToken = default);
        Task<(bool successded, string qrCodeBase64, string key)> GetLoginQrCode(CancellationToken cancellationToken = default);
        Task<bool> LoginStatus(CancellationToken cancellationToken = default);
        Task<bool> Logout(CancellationToken cancellationToken = default);
        Task<bool> PhoneCaptchaLoginAsync(string phoneNumber, string captcha, CancellationToken cancellationToken = default);
        Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default);
    }
}