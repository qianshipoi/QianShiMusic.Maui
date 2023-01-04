namespace NeteaseCloudMusicApi.Requests;

public class PersonalizedRequest : BaseRequest
{
    /// <summary>
    /// 总条数 默认30
    /// </summary>
    [AliasAs("limit")]
    public int? Limit { get; set; }
}