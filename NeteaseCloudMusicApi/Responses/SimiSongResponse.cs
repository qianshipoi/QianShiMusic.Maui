namespace NeteaseCloudMusicApi.Responses;

public class SimiSongResponse : BaseResponse
{
    public List<TopSong> Songs { get; set; } = new List<TopSong>();
}