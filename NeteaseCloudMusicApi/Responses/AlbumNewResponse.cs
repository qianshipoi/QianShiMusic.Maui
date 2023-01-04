namespace NeteaseCloudMusicApi.Responses;

public class AlbumNewResponse : BaseResponse
{
    public int Total { get; set; }
    public List<Album> Albums { get; set; } = new List<Album>();
}