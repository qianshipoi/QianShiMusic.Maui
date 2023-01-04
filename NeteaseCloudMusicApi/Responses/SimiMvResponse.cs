namespace NeteaseCloudMusicApi.Responses;

public class SimiMvResponse : BaseResponse
{
    public List<MovieVideo> Mvs { get; set; } = default!;
}