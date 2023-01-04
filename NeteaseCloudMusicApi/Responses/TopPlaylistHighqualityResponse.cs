namespace NeteaseCloudMusicApi.Responses;

public class TopPlaylistHighqualityResponse : BaseResponse
{
    public long Total { get; set; }
    public bool More { get; set; }
    public long Lasttime { get; set; }
    public List<Playlist> Playlists { get; set; } = new List<Playlist>();
}