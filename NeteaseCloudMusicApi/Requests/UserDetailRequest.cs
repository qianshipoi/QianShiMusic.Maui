namespace NeteaseCloudMusicApi.Requests;

public record UserDetailRequest(int? Limit, int? Offset, [property: AliasAs("uid")] long Uid) : PagedRequestBase(Limit, Offset)
{
    public UserDetailRequest(long uid) : this(null, null, uid)
    {
    }
}