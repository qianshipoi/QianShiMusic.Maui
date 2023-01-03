using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Services;
using QianShiMusicClient.Maui.Views;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public sealed partial class HomeViewModel : ViewModelBase
{
    private readonly IPopupService _popupService;

    public ObservableCollection<HomeOption> Options { get; }

    public ObservableCollection<Playlist> Playlists { get; }

    public HomeViewModel(IPopupService popupService)
    {
        _popupService = popupService;
        Options = new ObservableCollection<HomeOption>
        {
            new HomeOption("最近播放",IconFontIcons.Playfill),
            new HomeOption("本地/下载",IconFontIcons.Icondownload),
            new HomeOption("云盘",IconFontIcons.Yunpan),
            new HomeOption("已购",IconFontIcons.Goumaijilu),
            new HomeOption("我的好友",IconFontIcons.Haoyou),
            new HomeOption("收藏和赞",IconFontIcons.Shoucang),
            new HomeOption("我的播客",IconFontIcons.Podcast),
            new HomeOption("乐迷团",IconFontIcons.HeartFill),
        };

        Playlists = new ObservableCollection<Playlist>
        {
            new Playlist("日系/无前奏：开口即跪 一秒沦陷", "https://p1.music.126.net/-bT1aNnjdESQwlw38D5eJg==/109951164323807218.jpg",63141452),
            new Playlist("华语百首 | 回忆伤人无声，唱不尽世间遗憾", "https://p1.music.126.net/4L--5jGuNNCdRxL10n_0-g==/19057835044326350.jpg",212104400),
            new Playlist("电子·中国风 I 感受角徵宫商的荡气回肠", "https://p1.music.126.net/6imPsFlxX3iXwK_2TZGuQA==/109951164854408532.jpg",27375084),
            new Playlist("听说把糖放在枕头底下会做一个甜甜的梦", "https://p1.music.126.net/jrrexbEDtAZepzYYVXMA6w==/109951163138024517.jpg",26799544),
            new Playlist("【怀疑耳机坏了系列】耳机你对耳朵做了什么", "https://p1.music.126.net/np88MU-d3uL8iP1P0R4Tsw==/109951166685344262.jpg",29928112),
            new Playlist("试着做个善良的人", "https://p1.music.126.net/XyoVPk4TPfZpRxDfBFqXZw==/109951163944520221.jpg",23781032),
            new Playlist("如果你想听民谣，可以从这些歌曲开始。", "https://p1.music.126.net/KzeifdqziIovPjKqtEOdVA==/3274345632105421.jpg",58499312),
        };
    }

    [RelayCommand]
    void CreatePlaylistMoreOption()
    {
        _popupService.ShowMoreOptionPopup("我创建的歌单", new List<MoreOption>
         {
            new MoreOption("创建新歌单",IconFontIcons.Information_add){ Command = 
            MoreOptionHandlerCommand },
            new MoreOption("歌单管理",IconFontIcons.ARankinglistFill){ Command = MoreOptionHandlerCommand },
            new MoreOption("一键导入外部音乐",IconFontIcons.Import){ Command = MoreOptionHandlerCommand },
            new MoreOption("恢复歌单",IconFontIcons.Refresh){ Command = MoreOptionHandlerCommand },
         });
    }

    [RelayCommand]
    async Task MoreOptionHandler(MoreOption option)
    {
        await Toast.Make(option.Name).Show();
    }

    [RelayCommand]
    void OpenMenu()
    {
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        Shell.Current.FlyoutIsPresented = true;
    }
}
