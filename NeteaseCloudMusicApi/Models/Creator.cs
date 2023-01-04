namespace NeteaseCloudMusicApi.Models;

public class Creator
{
    public bool DefaultAvatar { get; set; }
    public long Province { get; set; }
    public int AuthStatus { get; set; }
    public bool Followed { get; set; }
    public string? AvatarUrl { get; set; }
    public int AccountStatus { get; set; }
    public int Gender { get; set; }
    public int City { get; set; }
    public long Birthday { get; set; }
    public long UserId { get; set; }
    public int UserType { get; set; }
    public string? Nickname { get; set; }
    public string? Signature { get; set; }
    public string? AliasAs { get; set; }
    public string? DetailAliasAs { get; set; }
    public long AvatarImgId { get; set; }
    public long BackgroundImgId { get; set; }
    public string? BackgroundUrl { get; set; }
    public int Authority { get; set; }
    public bool Mutual { get; set; }
    public List<string>? ExpertTags { get; set; }
    public Dictionary<int, string>? Experts { get; set; }
    public int DjStatus { get; set; }
    public int VipType { get; set; }
    public List<string>? RemarkName { get; set; }
    public int AuthenticationTypes { get; set; }
    public AvatarDetail? AvatarDetail { get; set; }
    public bool Anchor { get; set; }
    public string? BackgroundImgIdStr { get; set; }
    public string? AvatarImgIdStr { get; set; }
    public string? AvatarImgId_str { get; set; }
}

public class AvatarDetail
{
    public int UserType { get; set; }
    public int IdentityLevel { get; set; }
    public string? IdentityIconUrl { get; set; }
}