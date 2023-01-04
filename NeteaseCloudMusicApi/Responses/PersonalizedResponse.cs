namespace NeteaseCloudMusicApi.Responses;

public class PersonalizedResponse : BaseResponse
{
    public bool HasTaste { get; set; }
    public int Category { get; set; }
    public List<PersonalizedPlaylist> Result { get; set; } = new List<PersonalizedPlaylist>();
}