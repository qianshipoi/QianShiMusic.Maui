using QianShiMusic.ViewModels;

namespace QianShiMusic.Views;

public partial class FoundPage : ContentPage
{
	public FoundPage(FoundPageViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}
}