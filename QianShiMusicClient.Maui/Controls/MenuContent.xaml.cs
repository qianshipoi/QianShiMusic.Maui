using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.ViewModels;

namespace QianShiMusicClient.Maui.Controls;

public partial class MenuContent : ContentView
{
	public MenuContent()
	{
		InitializeComponent();
		this.BindingContext = ServiceHelper.GetRequiredService<MenuViewModel>();
	}
}