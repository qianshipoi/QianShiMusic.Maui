namespace NeteaseCloudMusicApi.Responses;

public class TopSongResponse : BaseResponse
{
    public List<TopSong> Data { get; set; } = new List<TopSong>();

}