namespace NeteaseCloudMusicApi.Responses;

public class ArtistTopSongResponse : BaseResponse
{
    public bool More { get; set; }
    public List<Song> Songs { get; set; } = new();
}