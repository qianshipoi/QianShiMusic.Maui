namespace NeteaseCloudMusicApi.Models;

public class Toplist
{
    public long Id { get; set; }
    public string UpdateFrequency { get; set; } = null!;
    public string CoverImgUrl { get; set; } = null!;
    public string AliasAs { get; set; } = null!;
    public string Name { get; set; } = null!;
    public long PlayCount { get; set; }
}