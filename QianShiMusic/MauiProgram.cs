using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using Mopups.Hosting;

using NeteaseCloudMusicApi;

using QianShiMusic.IServices;
using QianShiMusic.Models;
using QianShiMusic.Services;
using QianShiMusic.ViewModels;
using QianShiMusic.Views;

using SkiaSharp.Views.Maui.Controls.Hosting;

using UraniumUI;

namespace QianShiMusic
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()
                .UseUraniumUI()
                .UseUraniumUIMaterial()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("iconfont.ttf", IconFontIcons.FontFamily);
                })
                .ConfigureMopups(() =>
                 {
                 })
                .Services.ConfigureService();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }


        public static IServiceCollection ConfigureService(this IServiceCollection services)
        {
            services.AddSingleton<SplashScreenPage>();
            services.AddSingleton<AppShell>();
            services.AddSingleton<MainPage, MainPageViewModel>();
            services.AddSingleton<FoundPage, FoundPageViewModel>();
            services.AddSingleton<SettingsPage, SettingsPageViewModel>();
            services.AddSingleton<LoginPage, LoginViewModel>();

            services.AddTransient<ILoginService, LoginService>();
            services.AddTransient<INotificationService, NotificationService>();

            services.AddSingleton(typeof(IMusicService), (serviceProvider) =>
            {
                var cookieStr = Preferences.Get("cookie", string.Empty);
                ApiClient.Init(AppConst.MusicApi, cookieStr);
                return ApiClient.Current;
            });

            return services;
        }
    }
}