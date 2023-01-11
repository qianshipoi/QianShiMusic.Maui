using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage(MainViewModel viewModel)
	{
		InitializeComponent();
		this.BindingContext = viewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		(BindingContext as MainViewModel)!.Init();
    }
}