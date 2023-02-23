namespace NeteaseCloudMusicApi.Requests;

public class AlbumNewRequest : PagedRequestBase
{
    [AliasAs("area")]
    public string? Area { get; set; } = "ALL";
}