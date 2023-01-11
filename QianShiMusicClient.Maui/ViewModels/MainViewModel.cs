using CommunityToolkit.Mvvm.ComponentModel;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    int _currentViewIndex;

    public List<TabBarItem> Tabs { get; } 

    public MainViewModel()
    {
        var foundVm = ServiceHelper.GetRequiredService<FoundViewModel>();
        var homeVm = ServiceHelper.GetRequiredService<HomeViewModel>();

        Tabs = new List<TabBarItem>
        {
            new TabBarItem("发现",IconFontIcons.Faxian, typeof(FoundView), foundVm),
            new TabBarItem("我的",IconFontIcons.Music, typeof(HomeView),homeVm),
        };
    }
}
