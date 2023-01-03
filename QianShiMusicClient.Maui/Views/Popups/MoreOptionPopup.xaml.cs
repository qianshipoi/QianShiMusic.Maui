using Mopups.Pages;
using Mopups.Services;

using QianShiMusicClient.Maui.Models;

using System.Windows.Input;

namespace QianShiMusicClient.Maui.Views.Popups;

public partial class MoreOptionPopup : PopupPage
{
    public MoreOptionPopup(string title, List<MoreOption> options)
    {
        InitializeComponent();
        TitleControl.Text = title;
        OptionsControl.ItemsSource = options;
    }

    private void OptionsControl_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is MoreOption option && (option.Command?.CanExecute(option.CommandParameter) ?? false))
        {
            option.Command.Execute(option.CommandParameter);
            // close popup
            if (option.ClostAfterExecution)
            {
                _ = MopupService.Instance.PopAsync();
            }
        }
    }
}
