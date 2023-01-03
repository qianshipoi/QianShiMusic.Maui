using CommunityToolkit.Maui.Views;

using Mopups.Services;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views.Popups;

namespace QianShiMusicClient.Maui.Services;

public class PopupService : IPopupService
{
    public async Task ShowMoreOptionPopup(string title, List<MoreOption> options)
    {
       await  MopupService.Instance.PushAsync(new MoreOptionPopup(title, options));
    }
}