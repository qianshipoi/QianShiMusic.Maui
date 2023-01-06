namespace NeteaseCloudMusicApi;

public class CookieInfo
{
#pragma warning disable CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    public CookieInfo()
#pragma warning restore CS8618 // 在退出构造函数时，不可为 null 的字段必须包含非 null 值。请考虑声明为可以为 null。
    {

    }
    public CookieInfo(Cookie cookie)
    {
        this.Name = cookie.Name;
        this.Value = cookie.Value;
        this.Path = cookie.Path;
        this.Domain = cookie.Domain;
    }
    public string Name { get; set; }
    public string Value { get; set; }
    public string Path { get; set; }
    public string Domain { get; set; }
    public Cookie ToCookie()
    {
        return new Cookie(this.Name, this.Value, this.Path, this.Domain);
    }
}
