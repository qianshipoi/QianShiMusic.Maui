namespace NeteaseCloudMusicApi.Responses;

public class LikelistResponse : BaseResponse
{
    public long CheckPoint { get; set; }
    public List<long> Ids { get; set; } = new();
}