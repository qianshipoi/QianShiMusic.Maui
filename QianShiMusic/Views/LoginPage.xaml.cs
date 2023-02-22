using QianShiMusic.ViewModels;

namespace QianShiMusic.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}