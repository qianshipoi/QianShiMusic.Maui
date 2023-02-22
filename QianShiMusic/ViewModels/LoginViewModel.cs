using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Storage;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusic.Helpers;
using QianShiMusic.IServices;

namespace QianShiMusic.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        readonly ILoginService _loginService;

        Timer? _updateQrCodeTimer;
        Timer? _checkTimer;
        string? _key;
        string? _base64QrCode;

        [ObservableProperty]
        ImageSource? _authQrCodeImage;

        public LoginViewModel(ILoginService loginService)
        {
            _loginService = loginService;
            _ = Init();
        }

        [RelayCommand]
        async Task Save()
        {
            if (string.IsNullOrWhiteSpace(_base64QrCode))
            {
                return;
            }

            var bytes = Convert.FromBase64String(_base64QrCode.Replace("data:image/png;base64,", ""));

            using var stream = new MemoryStream(bytes);
            try
            {
                var fileLocation = await FileSaver.Default.SaveAsync(DateTime.Now.Ticks + ".png", stream, default);
                await Toast.Make($"File is saved: {fileLocation}").Show();
            }
            catch (Exception ex)
            {
                await Toast.Make($"File is not saved, {ex.Message}").Show();
            }
        }

        async Task Init()
        {
            await GenerateQrCodeImage();
            _checkTimer = new Timer(state => _ = CheckAuthStatus(), null, 2000, 2000);
        }

        async Task GenerateQrCodeImage()
        {
            _updateQrCodeTimer?.Dispose();

            try
            {
                var (successded, qrCode, key) = await _loginService.GetLoginQrCode();
                _key = key;
                _base64QrCode = qrCode;
                if (!successded)
                {
                    throw new Exception("获取二维码失败");
                }

                MainThread.BeginInvokeOnMainThread(() =>
                {
                    AuthQrCodeImage = ImageSource.FromStream(() =>
                    {
                        qrCode = qrCode.Replace("data:image/png;base64,", "");
                        var bytes = Convert.FromBase64String(qrCode);
                        return new MemoryStream(bytes);
                    });
                });

                _updateQrCodeTimer = new Timer(state => _ = GenerateQrCodeImage(), null, 60000, 60000);
            }
            catch (Exception ex)
            {
                await Toast.Make(ex.Message).Show();
            }
        }

        async Task CheckAuthStatus()
        {
            if (string.IsNullOrWhiteSpace(_key)) return;
            var (result, needUpdate) = await _loginService.CheckQrCodeLogin(_key);

            if (needUpdate)
            {
                ClearAuthTimer();
                await GenerateQrCodeImage();
                _checkTimer = new Timer(state => _ = CheckAuthStatus(), null, 2000, 2000);
                return;
            }

            if (result)
            {
                // login success!
                ClearAuthTimer();
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await Task.Delay(1000); // 唤醒后执行
                    App.Current.MainPage = ServiceHelper.GetRequiredService<AppShell>();
                });
            }
        }

        void ClearAuthTimer()
        {
            _checkTimer?.Dispose();
            _updateQrCodeTimer?.Dispose();
        }
    }
}
