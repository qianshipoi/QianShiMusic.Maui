using QianShiMusic.Helpers;
using QianShiMusic.Views;

namespace QianShiMusic
{
    public partial class App : Application
    {
        public static new App Current => (App)Application.Current!;

        public App()
        {
            InitializeComponent();

            UserAppTheme = Settings.Theme;

            MainPage = ServiceHelper.GetRequiredService<SplashScreenPage>();
        }
    }
}