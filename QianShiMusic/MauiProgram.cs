using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using Mopups.Hosting;

using NeteaseCloudMusicApi;

using QianShiMusic.Models;
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
            services.AddTransient<MainPage, MainPageViewModel>();
            services.AddTransient<FoundPage, FoundPageViewModel>();
            services.AddTransient<SettingsPage, SettingsPageViewModel>();

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