using CommunityToolkit.Mvvm.ComponentModel;

namespace QianShiMusicClient.Maui.Models;

public class Carousel
{
    public string Path { get; set; }

    public Carousel(string path)
    {
        Path = path;
    }
}

public class Song
{
    public string PicUrl { get; set; }

    public string Name { get; set; }

    public int PlayCount { get; set; }
    public Song(string name, string picUrl, int playCount)
    {
        Name = name;
        PicUrl = picUrl;
        PlayCount = playCount;
    }

}

public class HomeOption
{
    public string Name { get; set; }
    public string Icon { get; set; }

    public HomeOption(string name, string icon)
    {
        Name = name;
        Icon = icon;
    }
}

public partial class TabBarItem : ObservableObject
{
    public string Name { get; set; }
    public string Icon { get; set; }
    [ObservableProperty]
    private bool _isSelected;
    public Type ViewType { get; set; }
    public TabBarItem(string name, string icon, bool isSelected, Type viewType)
    {
        Name = name;
        Icon = icon;
        IsSelected = isSelected;
        ViewType = viewType;
    }
}
