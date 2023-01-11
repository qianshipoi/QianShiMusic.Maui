using CommunityToolkit.Mvvm.ComponentModel;

using QianShiMusicClient.Maui.Helpers;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    int _currentViewIndex;

    public FoundViewModel? FoundViewModel { get; private set; }
    public HomeViewModel? HomeViewModel { get; private set; }

    public List<string> Tabs { get; } = new List<string>()
    {
        "我的",
        "发现"
    };

    public void Init()
    {
        FoundViewModel = ServiceHelper.GetRequiredService<FoundViewModel>();
        HomeViewModel = ServiceHelper.GetRequiredService<HomeViewModel>();
    }
}
