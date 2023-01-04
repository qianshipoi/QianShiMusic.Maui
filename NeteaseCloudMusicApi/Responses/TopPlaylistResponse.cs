namespace NeteaseCloudMusicApi.Responses;

public class TopPlaylistResponse : BaseResponse
{
    public long Total { get; set; }
    public bool More { get; set; }
    public string? Cat { get; set; }
    public List<Playlist> Playlists { get; set; } = new List<Playlist>();
}