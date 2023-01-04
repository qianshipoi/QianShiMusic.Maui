namespace NeteaseCloudMusicApi.Responses;

public class AlbumSublistResponse : BaseResponse
{
    public int Count { get; set; }

    public bool HasMore { get; set; }

    public int PaidCount { get; set; }

    public List<Album> Data { get; set; } = new List<Album>();
}