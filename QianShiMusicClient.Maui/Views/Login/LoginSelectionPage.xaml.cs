using QianShiMusicClient.Maui.ViewModels.Login;

namespace QianShiMusicClient.Maui.Views;

public partial class LoginSelectionPage : ContentPage
{
    public LoginSelectionPage(LoginSelectionViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }
}