using CommunityToolkit.Mvvm.ComponentModel;

using System.Windows.Input;

namespace QianShiMusicClient.Maui.Models;

public record Carousel(string Path);

public record Song(string Name, string PicUrl, int PlayCount);

public record HomeOption(string Name, string Icon)
{
    public ICommand? Command { get; init; }
}

public record Playlist(string Name, string PicUrl, int SongCount);

public class MoreOption
{
    public string Name { get; set; }

    public string Icon { get; set; }

    public ICommand? Command { get; set; }

    public object? CommandParameter { get; set; }

    public bool ClostAfterExecution { get; set; } = true;

    public MoreOption(string name, string icon)
    {
        Name = name;
        Icon = icon;
        if (CommandParameter == null)
        {
            CommandParameter = this;
        }
    }
}

public class TabBarItem
{
    public string Name { get; set; }
    public string Icon { get; set; }
    public Type ViewType { get; set; }
    public object ViewModel { get; set; }

    public TabBarItem(string name, string icon, Type viewType, object viewModel)
    {
        Name = name;
        Icon = icon;
        ViewType = viewType;
        ViewModel = viewModel;
    }
}
