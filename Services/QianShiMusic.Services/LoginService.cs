using NeteaseCloudMusicApi;
using NeteaseCloudMusicApi.Requests;
using NeteaseCloudMusicApi.Responses;

using QianShiMusic.IServices;

using System.Security.Cryptography;
using System.Text;

namespace QianShiMusic.Services
{
    // All the code in this file is included in all platforms.
    public class LoginService : ILoginService
    {
        readonly IMusicService _musicService;
        readonly INotificationService _notificationService;

        long Now => DateTime.Now.Ticks;

        public bool IsLoggedIn { get; private set; }

        public string? Cookie { get; private set; }

        public LoginService(
            IMusicService musicService,
            INotificationService notificationService)
        {
            _musicService = musicService;
            _notificationService = notificationService;
        }

        private async Task<bool> HandleLoginAsync(LoginResponse? response)
        {
            if (response == null)
            {
                await _notificationService.Show("网络异常");
                return false;
            }
            if (response.Code != 200)
            {
                await _notificationService.Show(response.Msg ?? "账号或密码错误");
                return false;
            }

            Preferences.Set("cookie", ApiClient.GetCookieString());
            Cookie = response.Cookie;
            IsLoggedIn = true;
            return true;
        }

        public async Task<bool> PhonePwdLoginAsync(string phoneNumber, string password, CancellationToken cancellationToken = default)
        {
            var response = await _musicService.LoginCellphone(new LoginCellphoneRequest(phoneNumber) { Md5Password = ToMd5(password).ToLower(), Time = DateTime.Now.Ticks }, cancellationToken);
            return await HandleLoginAsync(response);
        }

        public async Task<bool> CaptchaSentAsync(string phoneNumber, CancellationToken cancellationToken = default)
        {
            var response = await _musicService.CaptchaSent(new CaptchaSentRequest(phoneNumber) { Time = DateTime.Now.Ticks }, cancellationToken);
            if (response.Code != 200)
            {
                await _notificationService.Show(response.Msg ?? response.Message ?? "手机号码不符合规范");
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
            var response = await _musicService.Login(new LoginRequest(email) { Md5Password = ToMd5(password).ToLower(), Time = DateTime.Now.Ticks }, cancellationToken);
            return await HandleLoginAsync(response);
        }

        public async Task<(bool successded, string qrCodeBase64, string key)> GetLoginQrCode(CancellationToken cancellationToken = default)
        {
            var keyResponse = await _musicService.LoginQrKey(new BaseRequest(DateTime.Now.Ticks), cancellationToken);

            if (keyResponse.Code != 200)
            {
                await _notificationService.Show(keyResponse.Msg ?? keyResponse.Message ?? "获取二维码失败");
                return (false, string.Empty, string.Empty);
            }

            var urlResponse = await _musicService.LoginQrCreate(new LoginQrCreateRequest(keyResponse.Data.Unikey, true, DateTime.Now.Ticks), cancellationToken);

            if (urlResponse.Code != 200)
            {
                await _notificationService.Show(urlResponse.Msg ?? urlResponse.Message ?? "获取二维码失败");
                return (false, string.Empty, string.Empty);
            }

            return (true, urlResponse.Data.Qrimg!, keyResponse.Data.Unikey);
        }

        public async Task<(bool result, bool update)> CheckQrCodeLogin(string key, CancellationToken cancellationToken = default)
        {
            var response = await _musicService.LoginQrCheck(new LoginQrCheckRequest(key, Now), cancellationToken);

            if (response.Code == 803)
            {
                // 授权成功
                Preferences.Set("cookie", ApiClient.GetCookieString());
                Cookie = response.Cookie;
                IsLoggedIn = true;
                return (true, false);
            }
            else if (response.Code == 800)
            {
                // 更新二维码
                return (false, true);
            }
            else
            {
                // 801 带扫描  802 授权中
                return (false, false);
            }
        }

        public async Task<bool> LoginStatus(CancellationToken cancellationToken = default)
        {
            var response = await _musicService.LoginStatus(new BaseRequest() { Time = DateTime.Now.Ticks }, cancellationToken);
            if (response.Data.Profile is null)
            {
                await _notificationService.Show("登录已过期");
                return false;
            }

            IsLoggedIn = true;
            return true;
        }

        public async Task<bool> Logout(CancellationToken cancellationToken = default)
        {
            var response = await _musicService.Logout(cancellationToken: cancellationToken);
            if (response.Code == 200)
            {
                Preferences.Remove("cookie");
            }
            return response.Code == 200;
        }

        private static string ToMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // 将输入字符串转换为字节数组并计算哈希数据  
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // 创建一个 Stringbuilder 来收集字节并创建字符串  
            StringBuilder str = new StringBuilder();
            // 循环遍历哈希数据的每一个字节并格式化为十六进制字符串  
            for (int i = 0; i < data.Length; i++)
            {
                str.Append(data[i].ToString("x2"));//加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
            }
            // 返回十六进制字符串  
            return str.ToString();
        }
    }
}