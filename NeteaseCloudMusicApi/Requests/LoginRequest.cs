namespace NeteaseCloudMusicApi.Requests;

public class LoginRequest : BaseRequest
{
    /// <summary>
    /// 163 网易邮箱
    /// </summary>
    [AliasAs("email")]
    public string Email { get; set; } = default!;

    public LoginRequest(string email)
    {
        Email = email;
    }

    /// <summary>
    /// 密码
    /// </summary>
    [AliasAs("password")]
    public string? Password { get; set; }

    /// <summary>
    /// md5 加密后的密码,传入后 password 将失效
    /// </summary>
    [AliasAs("md5_password")]
    public string? Md5Password { get; set; }
}