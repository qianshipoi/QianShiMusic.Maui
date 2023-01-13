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
        Main.ChildAdded += Main_ChildAdded;
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
}