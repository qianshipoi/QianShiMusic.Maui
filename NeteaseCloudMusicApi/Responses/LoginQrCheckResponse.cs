namespace NeteaseCloudMusicApi.Responses;

public class LoginQrCheckResponse : BaseResponse
{
    /// <summary>
    /// 800 二维码已过期 801 等待扫码 802 授权中 803 授权成功
    /// </summary>
    public new int Code { get; set; }

    /// <summary>
    /// 头像 仅当Code为802时有值
    /// </summary>
    public string? AvatarUrl { get; set; }

    /// <summary>
    /// 昵称 仅当Code为802时有值
    /// </summary>
    public string? Nickname { get; set; }

    /// <summary>
    /// 凭据 仅当Code为803时有值
    /// </summary>
    public string? Cookie { get; set; }
}