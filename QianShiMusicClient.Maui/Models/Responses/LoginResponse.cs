namespace QianShiMusicClient.Maui.Models.Responses;

public class LoginResponse : BaseResponse
{
    public int LoginType { get; set; }
    public string? Token { get; set; }
    public Account Account { get; set; } = default!;
    public Profile Profile { get; set; } = default!;
    public string? Cookie { get; set; }
    public List<Binding>? Bindings { get; set; }
}

public record Binding
{
    public int UserId { get; set; }
    public string? Url { get; set; }
    public bool Expired { get; set; }
    public dynamic? BindingTime { get; set; }
    public string? TokenJsonStr { get; set; }
    public long ExpiresIn { get; set; }
    public int RefreshTime { get; set; }
    public dynamic? Id { get; set; }
    public int Type { get; set; }
}
public record Account
{
    public long Id { get; set; }
    public bool AnonimousUser { get; set; }
    public int Ban { get; set; }
    public sbyte BaoyueVersion { get; set; }
    public sbyte DonateVersion { get; set; }
    public long CreateTime { get; set; }
    public bool PaidFee { get; set; }
    public sbyte Status { get; set; }
    public sbyte TokenVersion { get; set; }
    public sbyte Type { get; set; }
    public string UserName { get; set; } = default!;
    public sbyte VipType { get; set; }
    public sbyte WhitelistAuthority { get; set; }
}
public record Profile
{
    public sbyte AccountStatus { get; set; }
    public sbyte AccountType { get; set; }
    public bool Anchor { get; set; }
    public sbyte AuthStatus { get; set; }
    public bool Authenticated { get; set; }
    public int AuthenticationTypes { get; set; }
    public sbyte Authority { get; set; }
    public string AvatarUrl { get; set; } = default!;
    public string BackgroundUrl { get; set; } = default!;
    public long Birthday { get; set; }
    public int City { get; set; }
    public long CreateTime { get; set; }
    public bool DefaultAvatar { get; set; }
    public string? Description { get; set; }
    public string? DetailDescription { get; set; }
    public sbyte DjStatus { get; set; }
    public bool Followed { get; set; }
    public sbyte Gender { get; set; }
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
