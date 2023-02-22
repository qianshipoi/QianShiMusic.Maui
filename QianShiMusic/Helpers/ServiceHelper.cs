namespace QianShiMusic.Helpers;

public static class ServiceHelper
{
    public static TService? GetService<TService>() where TService : notnull => Current.GetService<TService>();

    public static TService GetRequiredService<TService>() where TService : notnull => Current.GetRequiredService<TService>();

    public static IServiceProvider Current =>
#if WINDOWS
    MauiWinUIApplication.Current.Services;
#elif ANDROID
    MauiApplication.Current.Services;
#elif IOS || MACCATALYST
        MauiUIApplicationDelegate.Current.Services;
#else
    null;
#endif
}