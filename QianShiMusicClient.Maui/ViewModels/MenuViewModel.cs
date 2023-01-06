using CommunityToolkit.Mvvm.Input;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Services;
using QianShiMusicClient.Maui.Views;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class MenuViewModel : ViewModelBase
{
    readonly ILoginService _loginService;

    public List<Menu> Menus { get; private set; }

    public List<Menu> MusicServices { get; private set; }

    public List<Menu> Others { get; private set; }

    public List<Menu> Detailed { get; private set; }

    public MenuViewModel(ILoginService loginService)
    {
        Menus = new List<Menu>
        {
             new Menu("我的消息",IconFontIcons.Message,"5"),
             new Menu("云贝中心",IconFontIcons.Message,"签到"),
             new Menu("创作者中心",IconFontIcons.Message),
        };
        MusicServices = new List<Menu>
        {
             new Menu("测测",IconFontIcons.Message,"点击查看今日运势"),
             new Menu("云村有票",IconFontIcons.Message),
             new Menu("多多西西口袋",IconFontIcons.Message),
             new Menu("商城",IconFontIcons.Goumaijilu,"大牌耳机3折起"),
             new Menu("Beat专区",IconFontIcons.Message,"完成9岁孩子的“说唱梦”"),
             new Menu("口袋彩铃",IconFontIcons.Message),
             new Menu("游戏专区",IconFontIcons.GameHandle)
        };
        Others = new List<Menu>
        {
             new Menu("设置",IconFontIcons.Message),
             new Menu("深色模式",IconFontIcons.Message),
             new Menu("定时关闭",IconFontIcons.Message),
             new Menu("个性装扮",IconFontIcons.Goumaijilu),
             new Menu("边听边存",IconFontIcons.Message,"未开启"),
             new Menu("音乐黑名单",IconFontIcons.Message),
             new Menu("青少年模式",IconFontIcons.GameHandle,"未开启")
        };
        Detailed = new List<Menu>
        {
             new Menu("我的订单",IconFontIcons.Message),
             new Menu("我的客服",IconFontIcons.Message),
             new Menu("分享网易云音乐",IconFontIcons.Message),
             new Menu("个人信息收集与使用清单",IconFontIcons.Goumaijilu),
             new Menu("个人信息第三方共享清单",IconFontIcons.Message),
             new Menu("个人信息与隐私保护",IconFontIcons.Message),
             new Menu("关于",IconFontIcons.GameHandle)
        };
        _loginService = loginService;
    }


    [RelayCommand]
    async Task Logout()
    {
        if (IsBusy) return;
        IsBusy = true;

        try
        {
            await _loginService.Logout();

            // to login page;
            App.Current.MainPage = new SplashScreenPage();
        }
        catch (Exception)
        {
        }
        finally
        {
            IsBusy = false;
        }
    }
}

