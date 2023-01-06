namespace NeteaseCloudMusicApi.Responses;

public class UserDetailResponse : BaseResponse
{
    public int Level { get; set; }
    public int ListenSongs { get; set; }
    public UserPoint UserPoint { get; set; } = null!;
    public bool MobileSign { get; set; }
    public bool PcSign { get; set; }
    public Profile Profile { get; set; } = null!;
    public bool PeopleCanSeeMyPlayRecord { get; set; }
    public List<Binding> Bindings { get; set; } = null!;
    public bool AdValid { get; set; }
    public bool NewUser { get; set; }
    public bool RecallUser { get; set; }
    public long CreateTime { get; set; }
    public int CreateDays { get; set; }
    public ProfileVillageInfo ProfileVillageInfo { get; set; } = null!;
}

public class Binding
{
    public long ExpiresIn { get; set; }
    public long RefreshTime { get; set; }
    public object? BindingTime { get; set; }
    public object? TokenJsonStr { get; set; }
    public string Url { get; set; } = null!;
    public bool Expired { get; set; }
    public long UserId { get; set; }
    public long Id { get; set; }
    public int Type { get; set; }
}

public class PrivacyItemUnlimit
{
    public bool Area { get; set; }
    public bool College { get; set; }
    public bool Gender { get; set; }
    public bool Age { get; set; }
    public bool VillageAge { get; set; }
}

public class Profile
{
    public PrivacyItemUnlimit PrivacyItemUnlimit { get; set; } = null!;
    public object? AvatarDetail { get; set; }
    public int AuthStatus { get; set; }
    public string DetailDescription { get; set; } = null!;
    public object Experts { get; set; } = null!;
    public object? ExpertTags { get; set; }
    public int AccountStatus { get; set; }
    public int VipType { get; set; }
    public string AvatarImgIdStr { get; set; } = null!;
    public string BackgroundImgIdStr { get; set; } = null!;
    public string Description { get; set; } = null!;
    public long Birthday { get; set; }
    public bool DefaultAvatar { get; set; }
    public int UserType { get; set; }
    public long CreateTime { get; set; }
    public string Nickname { get; set; } = null!;
    public object? RemarkName { get; set; }
    public int UserId { get; set; }
    public bool Mutual { get; set; }
    public long AvatarImgId { get; set; }
    public int Province { get; set; }
    public int City { get; set; }
    public int Gender { get; set; }
    public bool Followed { get; set; }
    public int DjStatus { get; set; }
    public string AvatarUrl { get; set; } = null!;
    public long BackgroundImgId { get; set; }
    public string BackgroundUrl { get; set; } = null!;
    public string Signature { get; set; } = null!;
    public int Authority { get; set; }
    public int Followeds { get; set; }
    public int Follows { get; set; }
    public bool Blacklist { get; set; }
    public int EventCount { get; set; }
    public int AllSubscribedCount { get; set; }
    public int PlaylistBeSubscribedCount { get; set; }
    public object? FollowTime { get; set; }
    public bool FollowMe { get; set; }
    public List<object>? ArtistIdentity { get; set; }
    public int CCount { get; set; }
    public bool InBlacklist { get; set; }
    public int SDJPCount { get; set; }
    public int PlaylistCount { get; set; }
    public int SCount { get; set; }
    public int NewFollows { get; set; }
}

public class ProfileVillageInfo
{
    public string Title { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
    public string TargetUrl { get; set; } = null!;
}

public class UserPoint
{
    public int UserId { get; set; }
    public int Balance { get; set; }
    public long UpdateTime { get; set; }
    public long Version { get; set; }
    public int Status { get; set; }
    public int BlockBalance { get; set; }
}