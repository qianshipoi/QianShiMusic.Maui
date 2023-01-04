namespace NeteaseCloudMusicApi.Responses;

public class AlbumNewestResponse : BaseResponse
{
    public List<Album> Albums { get; set; } = new();
}