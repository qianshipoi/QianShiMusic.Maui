namespace NeteaseCloudMusicApi.Responses;

public class RelatedPlaylistResponse : BaseResponse
{
    public List<Playlist>? Playlists { get; set; }
}