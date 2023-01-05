namespace QianShiMusicClient.Maui.Models;

public class Menu
{
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string? Tag { get; set; }

    public Menu(string name, string icon, string? tag = null)
    {
        Name = name;
        Icon = icon;
        Tag = tag;
    }
}
