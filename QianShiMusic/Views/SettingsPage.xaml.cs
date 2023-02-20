using QianShiMusic.ViewModels;

namespace QianShiMusic.Views;

public partial class SettingsPage : ContentPage
{
	public SettingsPage(SettingsPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}