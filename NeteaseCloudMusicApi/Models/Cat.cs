namespace NeteaseCloudMusicApi.Models;

public class Cat
{
    public string Name { get; set; } = null!;
    public int ResourceCount { get; set; }
    public int ImgId { get; set; }
    public string? ImgUrl { get; set; }
    public int Type { get; set; }
    public int Category { get; set; }
    public int ResourceType { get; set; }
    public bool Hot { get; set; }
    public bool Activity { get; set; }
}