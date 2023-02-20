using CommunityToolkit.Maui.Alerts;

using QianShiMusicClient.Maui.ViewModels;

using Sharpnado.Tabs;

namespace QianShiMusicClient.Maui.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        this.BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        //Main.ChildAdded += Main_ChildAdded;
    }
    int viewCount = 0;
    private void Main_ChildAdded(object? sender, ElementEventArgs e)
    {
        viewCount++;
        if (e.Element is DelayedView view && !view.IsLoaded)
        {
            if (viewCount > 1)
            {
                view.DelayInMilliseconds = viewCount * 1000;
            }
            view.LoadView();
        }
    }

    private void tabs_SelectedIndexChanged(object sender, Material.Components.Maui.Core.SelectedIndexChangedEventArgs e)
    {
        if (sender is Material.Components.Maui.Tabs tabs
            && tabs.Items[e.SelectedIndex].Content is Material.Components.Maui.FillGrid grid
            && grid.Children.FirstOrDefault() is Material.Components.Maui.BaseLazyView lazyView
            && !lazyView.IsLoaded)
        {
            lazyView.LoadViewAsync().AsTask().ContinueWith((task, state) =>
            {
                lazyView.Content.BindingContext = lazyView.BindingContext;
            }, null);
        }
    }
}