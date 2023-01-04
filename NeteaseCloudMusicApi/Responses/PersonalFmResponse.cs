namespace NeteaseCloudMusicApi.Responses;

public class PersonalFmResponse : BaseResponse
{
    public bool PopAdjust { get; set; }

    public List<TopSong> Data { get; set; } = default!;
}