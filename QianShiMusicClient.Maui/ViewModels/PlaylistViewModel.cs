using CommunityToolkit.Mvvm.ComponentModel;

using Material.Components.Maui.Core;

namespace QianShiMusicClient.Maui.ViewModels;

public partial class PlaylistViewModel : ViewModelBase
{
    [ObservableProperty]
    int _currentTypeIndex;

    public ItemCollection<Cat> Cats { get; }

    public PlaylistViewModel()
    {
        Cats = new ItemCollection<Cat>();
        Cats.Add(new Cat("推荐"));
        Cats.Add(new Cat("官方"));
        Cats.Add(new Cat("精品"));
    }

    public async Task LoadCatsAsync()
    {
        await Task.Delay(1000);

        MainThread.BeginInvokeOnMainThread(() =>
        {
            Cats.Add(new Cat("推荐"));
            Cats.Add(new Cat("推荐"));
            Cats.Add(new Cat("推荐"));
        });
    }
}

public class Cat
{
    public string Name { get; set; } = null!;

    public Cat(string name)
    {
        Name = name;
    }
}



