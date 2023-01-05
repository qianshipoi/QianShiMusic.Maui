namespace NeteaseCloudMusicApi.Requests;

public class BannerRequest : BaseRequest
{
    /// <summary>
    /// type:资源类型,对应以下类型,默认为 0 即 PC <br />
    /// 0: pc  1: android 2: iphone 3: ipad
    /// </summary>
    [AliasAs("type")]
    public sbyte Type { get; set; }

    public BannerRequest(sbyte type)
    {
        Type = type;
    }
}
