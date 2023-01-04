namespace NeteaseCloudMusicApi.Responses;

public class PlaylistHotResponse : BaseResponse
{
    public List<Tag> Tags { get; set; } = new List<Tag>();
}