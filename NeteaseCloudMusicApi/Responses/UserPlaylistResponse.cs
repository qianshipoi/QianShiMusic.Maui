namespace NeteaseCloudMusicApi.Responses;

public class UserPlaylistResponse : BaseResponse
{
    public bool More { get; set; }
    public string Version { get; set; } = default!;
    public List<Playlist> Playlist { get; set; } = default!;
}