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

            MainPage = ServiceHelper.GetRequiredService<SplashScreenPage>();
        }
    }
}