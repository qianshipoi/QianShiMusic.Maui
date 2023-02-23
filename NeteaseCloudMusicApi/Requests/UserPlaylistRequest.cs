namespace NeteaseCloudMusicApi.Requests;

public class UserPlaylistRequest : PagedRequestBase
{
    [AliasAs("uid")]
    public long Uid { get; set; }

    public UserPlaylistRequest(long uid)
    {
        Uid = uid;
    }
}
