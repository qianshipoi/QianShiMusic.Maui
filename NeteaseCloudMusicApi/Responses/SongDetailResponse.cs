namespace NeteaseCloudMusicApi.Responses;

public class SongDetailResponse : BaseResponse
{
    public List<Song> Songs { get; set; } = new List<Song>();
}