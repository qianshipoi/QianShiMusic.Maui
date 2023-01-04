namespace NeteaseCloudMusicApi.Responses;

public class CatlistResponse : BaseResponse
{
    public Cat? All { get; set; }
    public List<Cat> Sub { get; set; } = new List<Cat>();
    public Dictionary<int, string> Categories { get; set; } = new Dictionary<int, string>();
}