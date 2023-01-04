namespace NeteaseCloudMusicApi.Responses;

public class ArtistSublistResponse : BaseResponse
{
    public int Count { get; set; }
    public bool HasMore { get; set; }
    public List<Artist> Data { get; set; } = new List<Artist>();
}