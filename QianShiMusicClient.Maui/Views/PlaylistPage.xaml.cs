using Material.Components.Maui;
using Material.Components.Maui.Core;

using NeteaseCloudMusicApi;

using QianShiMusicClient.Maui.Helpers;
using QianShiMusicClient.Maui.ViewModels;
using QianShiMusicClient.Maui.Views.Playlists;

namespace QianShiMusicClient.Maui.Views;

public partial class PlaylistPage : ContentPage
{
    PlaylistViewModel ViewModel;

    readonly IMusicService _musicService;

    public PlaylistPage()
    {
        InitializeComponent();
        this.BindingContext = ViewModel = ServiceHelper.GetRequiredService<PlaylistViewModel>();
        _musicService = ServiceHelper.GetRequiredService<IMusicService>();
        Loaded += PlaylistPage_Loaded;
    }

    private void PlaylistPage_Loaded(object? sender, EventArgs e)
    {
        foreach (var cat in ViewModel.Cats)
        {
            AddView(cat);
        }

        ViewModel.Cats.OnAdded += Cats_OnAdded;
        _ = ViewModel.LoadCatsAsync();

        tabs.SelectedIndexChanged += Tabs_SelectedIndexChanged;
    }

    private void Tabs_SelectedIndexChanged(object? sender, SelectedIndexChangedEventArgs e)
    {
        var tabItem = tabs.Items[e.SelectedIndex];
        if (tabItem.Content is OfficialPlaylistView view
            //tabItem.Content is FillGrid grid
            //&& grid.Children.FirstOrDefault() is BaseLazyView view
            && !view.IsLoaded)
        {
            _ = view.ViewModel.LoadAsync();

            //if (view.BindingContext is PlaylistTypeViewModel viewModel)
            //{
            //    viewModel.LoadAsync().ContinueWith(async (task, state) =>
            //    {
            //        await view.LoadViewAsync();
            //    }, null);
            //}
        }
    }

    private void AddView(Cat cat)
    {
        var grid = new FillGrid();

        var view = new LazyView<OfficialPlaylistView>
        {
            BindingContext = new PlaylistTypeViewModel(cat.Name, _musicService)
        };

        //grid.Add(view);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            tabs.Items.Add(new TabItem
            {
                Text = cat.Name,
                Content = view
            });
        });
    }

    private void Cats_OnAdded(object? sender, ItemsChangedEventArgs<Cat> e)
    {
        if (sender is not null
            && sender is ItemCollection<Cat> cats
            && cats.Count > e.Index
            && cats[e.Index] is Cat cat)
        {
            AddView(cat);
        }
    }


}