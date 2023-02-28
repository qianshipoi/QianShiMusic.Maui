using MudBlazor.Services;

using NeteaseCloudMusicApi;

namespace QianShiMusic.MauiBlazor
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                })
                .Services.ConfigureService();

            builder.Services.AddMudServices();

            builder.Services.AddMauiBlazorWebView();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
#endif

            return builder.Build();
        }

        public static void ConfigureService(this IServiceCollection services)
        {
            services.AddSingleton(typeof(IMusicService), (serviceProvider) => {
                var cookieStr = Preferences.Get("cookie", string.Empty);
                ApiClient.Init(AppConst.MusicApi, cookieStr);
                return ApiClient.Current;
            });
        }
    }
}