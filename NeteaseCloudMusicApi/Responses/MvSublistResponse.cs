namespace NeteaseCloudMusicApi.Responses;

public class MvSublistResponse : BaseResponse
{
    public int Count { get; set; }
    public bool HasMore { get; set; }

    public List<MovieVideoSubject> Data { get; set; } = new();
}