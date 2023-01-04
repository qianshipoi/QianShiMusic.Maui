namespace NeteaseCloudMusicApi.Requests;

/// <param name="Limit"><inheritdoc/></param>
/// <param name="Offset"><inheritdoc/></param>
/// <param name="Uid">  用户 id </param>
public record UserRecordRequest(int? Limit, int? Offset, [property: AliasAs("uid")] long Uid) : PagedRequestBase(Limit, Offset)
{
    /// <summary>
    /// type=1 时只返回 weekData, type=0 时返回 allData
    /// </summary>
    [AliasAs("type")]
    public sbyte? Type { get; set; } = 0;

    public UserRecordRequest(long uid) : this(null, null, uid)
    {
    }
}