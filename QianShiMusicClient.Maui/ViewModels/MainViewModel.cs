using CommunityToolkit.Mvvm.ComponentModel;

using QianShiMusicClient.Maui.Helpers;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    int _currentViewIndex;

    public FoundViewModel FoundViewModel { get; private set; }
    public HomeViewModel HomeViewModel { get; private set; }

    public MainViewModel()
    {
        FoundViewModel = ServiceHelper.GetRequiredService<FoundViewModel>();
        HomeViewModel = ServiceHelper.GetRequiredService<HomeViewModel>();
    }
}
