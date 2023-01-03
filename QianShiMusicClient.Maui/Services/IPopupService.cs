using CommunityToolkit.Maui.Views;

using QianShiMusicClient.Maui.Models;
using QianShiMusicClient.Maui.Views.Popups;

namespace QianShiMusicClient.Maui.Services;

public interface IPopupService
{
    Task ShowMoreOptionPopup(string title, List<MoreOption> options);
}
