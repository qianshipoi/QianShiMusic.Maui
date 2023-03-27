using QianShiMusic.ViewModels;

namespace QianShiMusic.Views;

public partial class MainPage
{
	public MainPage(MainPageViewModel viewModel)
	{
		this.BindingContext = viewModel;
		InitializeComponent();
	}
}