using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public sealed partial class MainViewModel : ViewModelBase
{
    IServiceProvider _serviceProvider;

    [ObservableProperty]
    View _currentView;

    public ObservableCollection<TabBarItem> TabBarItems { get; private set; }

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        CurrentView = _serviceProvider.GetRequiredService<FoundView>();
        TabBarItems = new ObservableCollection<TabBarItem>
    {
        new TabBarItem("发现",IconFontIcons.Faxian,true,typeof(FoundView)),
        new TabBarItem("我的",IconFontIcons.Music,false,typeof(HomeView)),
    };

    }

    [RelayCommand]
    void Join(TabBarItem item)
    {
        if (item.IsSelected) return;
        TabBarItems.FirstOrDefault(x => x.IsSelected).IsSelected = false;
        item.IsSelected = true;
        CurrentView.Parent = null;
        CurrentView = null;
        CurrentView = _serviceProvider.GetRequiredService(item.ViewType) as View;
    }
}
