namespace NeteaseCloudMusicApi.Requests;

public class UserRecordRequest : PagedRequestBase
{
    /// <param name="Uid">  用户 id </param>
    [AliasAs("uid")]
    public long Uid { get; set; }

    /// <summary>
    /// type=1 时只返回 weekData, type=0 时返回 allData
    /// </summary>
    [AliasAs("type")]
    public sbyte? Type { get; set; } = 0;

    public UserRecordRequest(long uid)
    {
        Uid = uid;
    }
}