namespace NeteaseCloudMusicApi.Responses;

public class PlaylistTrackAllResponse : BaseResponse
{
    public List<Song> Songs { get; set; } = null!;

    public List<Privilege> Privileges { get; set; } = null!;
}