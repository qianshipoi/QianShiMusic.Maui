namespace NeteaseCloudMusicApi.Requests;

public class UserDetailRequest : PagedRequestBase
{
    [AliasAs("uid")]
    public long Uid { get; set; }

    public UserDetailRequest(long uid)
    {
        Uid = uid;
    }
}