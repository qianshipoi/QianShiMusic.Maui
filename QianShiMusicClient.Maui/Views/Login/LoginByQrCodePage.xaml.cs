using QianShiMusicClient.Maui.ViewModels.Login;

namespace QianShiMusicClient.Maui.Views.Login;

public partial class LoginByQrCodePage : ContentPage
{
	public LoginByQrCodePage(LoginByQrCodeViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}