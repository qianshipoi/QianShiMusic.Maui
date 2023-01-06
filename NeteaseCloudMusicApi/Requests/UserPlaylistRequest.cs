namespace NeteaseCloudMusicApi.Requests;

public record UserPlaylistRequest(int? Limit, int? Offset, [property: AliasAs("uid")] long Uid) : PagedRequestBase(Limit, Offset)
{
    public UserPlaylistRequest(long uid) : this(null, null, uid)
    {
    }
}

public record UserDetailRequest(int? Limit, int? Offset, [property: AliasAs("uid")] long Uid) : PagedRequestBase(Limit, Offset)
{
    public UserDetailRequest(long uid) : this(null, null, uid)
    {
    }
}