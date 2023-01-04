namespace NeteaseCloudMusicApi.Responses;

public class ArtistsResponse : BaseResponse
{
    public Artist Artist { get; set; } = default!;
    public bool More { get; set; }
    public List<Song> HotSongs { get; set; } = new List<Song>();
}