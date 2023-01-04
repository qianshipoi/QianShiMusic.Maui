namespace NeteaseCloudMusicApi.Responses;

public class SimiArtistResponse : BaseResponse
{
    public List<Artist> Artists { get; set; } = new List<Artist>();
}