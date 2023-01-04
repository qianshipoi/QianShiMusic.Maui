namespace NeteaseCloudMusicApi;

public class CookieInfo
{
    public CookieInfo()
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
