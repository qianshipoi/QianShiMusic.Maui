using QianShiMusicClient.Maui.ViewModels.Login;

namespace QianShiMusicClient.Maui.Views.Login;

public partial class LoginByPhonePage : ContentPage
{
    public LoginByPhoneViewModel ViewModel => (LoginByPhoneViewModel)BindingContext;

    public LoginByPhonePage(LoginByPhoneViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    protected override bool OnBackButtonPressed()
    {
        if (ViewModel.CurrentState == "password")
        {
            ViewModel.CurrentState = "captcha";
            return true;
        }
        if (ViewModel.CurrentState == "captcha")
        {
            ViewModel.CurrentState = "phone";
            return true;
        }

        return base.OnBackButtonPressed();
    }
}