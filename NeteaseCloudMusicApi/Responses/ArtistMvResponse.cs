namespace NeteaseCloudMusicApi.Responses;

public class ArtistMvResponse : BaseResponse
{
    public bool HasMore { get; set; }
    public List<MovieVideo> Mvs { get; set; } = default!;
}