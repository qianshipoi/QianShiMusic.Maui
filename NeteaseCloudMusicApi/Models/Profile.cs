namespace NeteaseCloudMusicApi.Models;

public record Profile
{
    public int AccountStatus { get; set; }
    public int AccountType { get; set; }
    public bool Anchor { get; set; }
    public int AuthStatus { get; set; }
    public bool Authenticated { get; set; }
    public int AuthenticationTypes { get; set; }
    public int Authority { get; set; }
    public string AvatarUrl { get; set; } = default!;
    public string BackgroundUrl { get; set; } = default!;
    public long Birthday { get; set; }
    public int City { get; set; }
    public long CreateTime { get; set; }
    public bool DefaultAvatar { get; set; }
    public string? AliasAs { get; set; }
    public string? DetailAliasAs { get; set; }
    public int DjStatus { get; set; }
    public bool Followed { get; set; }
    public int Gender { get; set; }
    public string LastLoginIP { get; set; } = default!;
    public long LastLoginTime { get; set; }
    public int LocationStatus { get; set; }
    public bool Mutual { get; set; }
    public string Nickname { get; set; } = default!;
    public int Province { get; set; }
    public string ShortUserName { get; set; } = default!;
    public long UserId { get; set; }
    public string UserName { get; set; } = default!;
    public int UserType { get; set; }
    public int VipType { get; set; }
    public long ViptypeVersion { get; set; }
}