using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Views;

public partial class FoundView : ContentView
{
	public FoundView()
	{
		InitializeComponent();
		this.BindingContext = ServiceHelper.GetRequiredService<FoundViewModel>();
	}
}