using CommunityToolkit.Maui;

using Microsoft.Extensions.Logging;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.ViewModels;
using QianShiMusicClient.Maui.Views;

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

        //services.AddTransientWithShellRoute<MessageDetailPage, MessageDetailViewModel>(nameof(MessageDetailPage));
        return services;
    }
}
