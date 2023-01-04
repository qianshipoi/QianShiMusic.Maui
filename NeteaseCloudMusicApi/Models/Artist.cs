namespace NeteaseCloudMusicApi.Models;

public class Artist
{
    public long Img1v1Id { get; set; }
    public long TopicPerson { get; set; }
    public long PicId { get; set; }
    public string? Trans { get; set; }
    public int AlbumSize { get; set; }
    public string? Img1v1Url { get; set; }

    [JsonPropertyName("picUrl")]
    public string CoverImgUrl { get; set; } = null!;

    public bool Followed { get; set; }
    public string? BriefDesc { get; set; }
    public List<string> Alias { get; set; } = new List<string>();
    public long MusicSize { get; set; }
    public string Name { get; set; } = null!;
    public long Id { get; set; }
    public string? Img1v1Id_str { get; set; }
    public long? AccountId { get; set; }
    public string IdentityIconUrl { get; set; } = string.Empty;
    public string Alg { get; set; } = string.Empty;

    public string Info { get; set; } = default!;
    public int? MvSize { get; set; }
}