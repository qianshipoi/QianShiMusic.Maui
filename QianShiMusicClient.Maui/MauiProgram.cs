﻿using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using Mopups.Hosting;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Services;
using QianShiMusicClient.Maui.ViewModels;
using QianShiMusicClient.Maui.ViewModels.Login;
using QianShiMusicClient.Maui.Views;
using QianShiMusicClient.Maui.Views.Login;

namespace QianShiMusicClient.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
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
        services.AddSingleton<AppShell, AppShellViewModel>();
        services.AddSingleton<MainPage, MainViewModel>();

        services.AddSingleton<FoundView, FoundViewModel>();
        services.AddSingleton<HomeView, HomeViewModel>();

        services.AddSingleton<IPopupService, PopupService>();

        services.AddSingleton<LoginSelectionPage, LoginSelectionViewModel>();
        services.AddSingleton<INavigationService, NavigationService>();

        services.AddTransient<LoginByEmailPage>();
        services.AddTransient<LoginByPhonePage>();
        services.AddTransient<ILoginService, LoginService>();

        //services.AddTransientWithShellRoute<MessageDetailPage, MessageDetailViewModel>(nameof(MessageDetailPage));
        return services;
    }
}