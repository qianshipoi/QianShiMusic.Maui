namespace NeteaseCloudMusicApi.Requests;

public record AlbumNewRequest(int? Limit, int? Offset) : PagedRequestBase(Limit, Offset)
{
    [AliasAs("area")]
    public string? Area { get; set; } = "ALL";
}