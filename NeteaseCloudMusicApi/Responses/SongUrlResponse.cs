namespace NeteaseCloudMusicApi.Responses;

public class SongUrlResponse
{
    public int Code { get; set; }
    public List<SongUrl> Data { get; set; } = new();
}