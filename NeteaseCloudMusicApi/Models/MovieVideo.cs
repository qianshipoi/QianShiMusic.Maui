namespace NeteaseCloudMusicApi.Models;

public class MovieVideo
{
    public string Alg { get; set; } = string.Empty;
    public string ArTransName { get; set; } = string.Empty;
    public string ArtistName { get; set; } = string.Empty;
    public long ArtistId { get; set; }
    public List<string>? Alias { get; set; }
    public Artist? Artist { get; set; }
    public List<Artist>? Artists { get; set; }
    public string? BriefDesc { get; set; }
    public string Cover { get; set; } = string.Empty;

    /// <summary>
    /// 有些接口返回为Cover 有些返回为Imgurl
    /// </summary>
    public string Imgurl { get => Cover; set => Cover = value; }

    public string CoverImgUrl { get => Cover; set => Cover = value; }
    public string Desc { get; set; } = string.Empty;
    public long Duration { get; set; }
    public long Id { get; set; }
    public long PlayCount { get; set; }
    public int Mark { get; set; }
    public string Name { get; set; } = string.Empty;
    public dynamic? TransNames { get; set; }
    public string? PublishTime { get; set; }
}