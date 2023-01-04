namespace NeteaseCloudMusicApi.Responses;

public class ToplistResponse : BaseResponse
{
    public List<Toplist> List { get; set; } = new();
}