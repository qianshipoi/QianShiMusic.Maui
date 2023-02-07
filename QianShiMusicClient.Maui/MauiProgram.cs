﻿using CommunityToolkit.Maui;

using Material.Components.Maui.Extensions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using Mopups.Hosting;

using NeteaseCloudMusicApi;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Services;
using QianShiMusicClient.Maui.ViewModels;
using QianShiMusicClient.Maui.ViewModels.Login;
using QianShiMusicClient.Maui.Views;
using QianShiMusicClient.Maui.Views.Login;

using Sharpnado.CollectionView;
using Sharpnado.Tabs;

using SkiaSharp.Views.Maui.Controls.Hosting;

namespace QianShiMusicClient.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseSkiaSharp()
            .UseSharpnadoTabs(loggerEnable: false)
            .UseSharpnadoCollectionView(loggerEnable:false)
            .UseMaterialComponents(
                new List<string>
                {
                    "Roboto-Regular.ttf",
                    "Roboto-Italic.ttf",
                    "Roboto-Medium.ttf",
                    "Roboto-MediumItalic.ttf",
                    "Roboto-Bold.ttf",
                    "Roboto-BoldItalic.ttf",
                }
            )
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

        Sharpnado.TaskLoaderView.Initializer.Initialize(true);

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
    public static IServiceCollection ConfigureService(this IServiceCollection services)
    {
        services.AddSingleton<AppShell, AppShellViewModel>();
        services.AddSingleton<MainPage, MainViewModel>();

        services.AddSingleton<FoundView, FoundViewModel>();
        services.AddSingleton<HomeView, HomeViewModel>();

        services.AddSingleton<IPopupService, PopupService>();

        services.AddSingleton<LoginSelectionPage, LoginSelectionViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddTransient<LoginByEmailPage, LoginByEmailViewModel>();
        services.AddTransient<LoginByPhonePage, LoginByPhoneViewModel>();
        services.AddTransient<LoginByQrCodePage, LoginByQrCodeViewModel>();
        services.AddTransient<ILoginService, LoginService>();
        services.AddSingleton<MenuViewModel>();

        services.AddSingleton<SplashScreenPage>();
        services.AddSingleton(typeof(IMusicService), (serviceProvider) =>
        {
            var cookieStr = Preferences.Get("cookie", string.Empty);
            ApiClient.Init("https://www.kuriyama.top/music-api", cookieStr);
            return ApiClient.Current;
        });

        services.AddSingletonWithShellRoute<PlaylistPage, PlaylistViewModel>(nameof(PlaylistPage));
        return services;
    }
}
