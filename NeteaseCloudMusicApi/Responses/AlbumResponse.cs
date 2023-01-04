namespace NeteaseCloudMusicApi.Responses;

public class AlbumResponse : BaseResponse
{
    public Album Album { get; set; } = new Album();

    public bool ResourceState { get; set; }

    public List<Song> Songs { get; set; } = new List<Song>();
}