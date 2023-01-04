namespace NeteaseCloudMusicApi.Responses;

public class PlaylistDetailResponse : BaseResponse
{
    public Playlist Playlist { get; set; } = new Playlist();

    public List<string>? Urls { get; set; }
}