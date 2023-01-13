using CommunityToolkit.Mvvm.ComponentModel;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views;

using Sharpnado.Tabs;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CurrentItem))]
    int _currentViewIndex;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "MVVMTK0034:Invalid task scheduler exception flow option usage", Justification = "<挂起>")]
    partial void OnCurrentViewIndexChanged(int value)
    {
        var current = Tabs[value];
        if (current != _currentItem)
        {
            _currentItem = current;
        }
    }

    [ObservableProperty]
    FoundViewModel _foundVm;

    [ObservableProperty]
    HomeViewModel _homeVm;

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(CurrentViewIndex))]
    TabBarItem? _currentItem;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("CommunityToolkit.Mvvm.SourceGenerators.ObservablePropertyGenerator", "MVVMTK0034:Invalid task scheduler exception flow option usage", Justification = "<挂起>")]
    partial void OnCurrentItemChanged(TabBarItem? value)
    {
        if (value is null)
        {
            _currentViewIndex = -1;
            return;
        }
        var index = Tabs.IndexOf(value);
        _currentViewIndex = index;
    }

    public List<TabBarItem> Tabs { get; }

    public MainViewModel()
    {
        _foundVm = ServiceHelper.GetRequiredService<FoundViewModel>();
        _homeVm = ServiceHelper.GetRequiredService<HomeViewModel>();

       

        Tabs = new List<TabBarItem>
        {
            new TabBarItem("发现",IconFontIcons.Faxian, typeof(FoundView), new FoundView()
            {
                BindingContext = _foundVm
            }),
            new TabBarItem("我的",IconFontIcons.Music, typeof(HomeView),new HomeView()),
        };
    }
}
