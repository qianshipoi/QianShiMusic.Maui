using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views;

public partial class FoundView : ContentView
{
	public FoundView(FoundViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}