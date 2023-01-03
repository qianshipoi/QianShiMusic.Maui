using CommunityToolkit.Mvvm.ComponentModel;

using System.Windows.Input;

namespace QianShiMusicClient.Maui.Models;

public record Carousel(string Path);

public record Song(string Name, string PicUrl, int PlayCount);

public record HomeOption(string Name, string Icon);

public record Playlist(string Name, string PicUrl, int SongCount);

public class MoreOption
{
    public string Name { get; set; }

    public string Icon { get; set; }

    public ICommand Command { get; set; }

    public object CommandParameter { get; set; }

    public bool ClostAfterExecution { get; set; } = true;

    public MoreOption(string name, string icon)
    {
        Name = name;
        Icon = icon;
        if(CommandParameter == null)
        {
            CommandParameter = this;
        }
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
