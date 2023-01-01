using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui;

public partial class AppShell : Shell
{
	public AppShell(AppShellViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}
