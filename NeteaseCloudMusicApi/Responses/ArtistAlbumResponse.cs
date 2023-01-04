namespace NeteaseCloudMusicApi.Responses;

public class ArtistAlbumResponse : BaseResponse
{
    public Artist Artist { get; set; } = default!;
    public bool More { get; set; }
    public List<Album> HotAlbums { get; set; } = default!;
}