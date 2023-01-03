using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Models;

using System.Collections.ObjectModel;

namespace QianShiMusicClient.Maui.ViewModels;

public sealed partial class FoundViewModel : ViewModelBase
{

    public ObservableCollection<Carousel> Carousels { get; private set; }

    public ObservableCollection<HomeOption> Options { get; private set; }

    public ObservableCollection<Song> Songs { get; private set; }

    public ObservableCollection<List<Song>> RelevantSongs { get; private set; }

    public FoundViewModel()
    {
        Carousels = new ObservableCollection<Carousel>
        {
            new Carousel("https://p1.music.126.net/g8VFvBYoyNQwif0zzu_0Pg==/109951168196985342.jpg"),
            new Carousel("https://p1.music.126.net/taNRDYPEF4YqkqWP7NSEjQ==/109951168196994605.jpg"),
            new Carousel("https://p1.music.126.net/spFUvT1vq6F0ZtkEiUbQvw==/109951168195626467.jpg"),
            new Carousel("https://p1.music.126.net/dBu87Tbl8Y9WdMZkvPozEg==/109951168196009941.jpg"),
            new Carousel("https://p1.music.126.net/IzHUb7nnYujjhijFUdwnvQ==/109951168195636252.jpg"),
            new Carousel("https://p1.music.126.net/w5HIyS37frvACUOtOONqJw==/109951168196016869.jpg"),
        };
        Options = new ObservableCollection<HomeOption>
        {
            new HomeOption("每日推荐",IconFontIcons.CalendarFill),
            new HomeOption("私人FM",IconFontIcons.BxsRadio),
            new HomeOption("歌单",IconFontIcons.Gedan),
            new HomeOption("排行榜",IconFontIcons.ARankinglistFill),
            new HomeOption("有声书",IconFontIcons.Book),
            new HomeOption("数字专辑",IconFontIcons.BxsAlbum),
            new HomeOption("关注新歌",IconFontIcons.Music),
            new HomeOption("一歌一遇",IconFontIcons.Cards),
            new HomeOption("收藏家",IconFontIcons.HammerFill),
            new HomeOption("游戏专区",IconFontIcons.GameHandle)
        };
        Songs = new ObservableCollection<Song>
        {
            new Song("日系/无前奏：开口即跪 一秒沦陷", "https://p1.music.126.net/-bT1aNnjdESQwlw38D5eJg==/109951164323807218.jpg",63141452),
            new Song("华语百首 | 回忆伤人无声，唱不尽世间遗憾", "https://p1.music.126.net/4L--5jGuNNCdRxL10n_0-g==/19057835044326350.jpg",212104400),
            new Song("电子·中国风 I 感受角徵宫商的荡气回肠", "https://p1.music.126.net/6imPsFlxX3iXwK_2TZGuQA==/109951164854408532.jpg",27375084),
            new Song("听说把糖放在枕头底下会做一个甜甜的梦", "https://p1.music.126.net/jrrexbEDtAZepzYYVXMA6w==/109951163138024517.jpg",26799544),
            new Song("【怀疑耳机坏了系列】耳机你对耳朵做了什么", "https://p1.music.126.net/np88MU-d3uL8iP1P0R4Tsw==/109951166685344262.jpg",29928112),
            new Song("试着做个善良的人", "https://p1.music.126.net/XyoVPk4TPfZpRxDfBFqXZw==/109951163944520221.jpg",23781032),
            new Song("如果你想听民谣，可以从这些歌曲开始。", "https://p1.music.126.net/KzeifdqziIovPjKqtEOdVA==/3274345632105421.jpg",58499312),
        };
        RelevantSongs = new ObservableCollection<List<Song>>
        {
            Songs.Take(3).ToList(),
            Songs.Skip(3).Take(3).ToList(),
            Songs.Skip(6).Take(3).ToList()
        };
    }

    [RelayCommand]
    async Task UpdateData()
    {
        IsBusy = true;
        try
        {
            await Task.Delay(2000);
        }
        finally
        {
            IsBusy = false;
        }
    }

    [RelayCommand]
    void OpenMenu()
    {
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Locked;
        Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        Shell.Current.FlyoutIsPresented = true;
    }
}
