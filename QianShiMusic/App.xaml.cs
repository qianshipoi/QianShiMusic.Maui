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

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = base.CreateWindow(activationState);
            window.Title = "QianShi Music";
            window.MinimumHeight = 800;
            window.MinimumWidth = 1200;

            window.Height = 800;
            window.Width = 1200;

            return window;
        }
    }
}