namespace NeteaseCloudMusicApi.Responses;

public class ArtistSongsResponse : BaseResponse
{
    public bool More { get; set; }

    public int Total { get; set; }

    public List<Song> Songs { get; set; } = new();
}