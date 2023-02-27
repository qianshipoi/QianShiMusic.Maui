namespace NeteaseCloudMusicApi.Responses;

public class SongUrlResponse : BaseResponse
{
    public List<SongUrl> Data { get; set; } = new();
}