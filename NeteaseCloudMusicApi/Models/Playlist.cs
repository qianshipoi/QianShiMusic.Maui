namespace NeteaseCloudMusicApi.Models;

public class Playlist
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public long TrackNumberUpdateTime { get; set; }
    public int Status { get; set; }
    public long UserId { get; set; }
    public long CreateTime { get; set; }
    public long UpdateTime { get; set; }
    public int SubscribedCount { get; set; }
    public int TrackCount { get; set; }
    public int ColudTrackCount { get; set; }
    public string CoverImgUrl { get; set; } = null!;
    public long CoverImgId { get; set; }
    public string? AliasAs { get; set; }
    public List<string>? Tags { get; set; }
    public long PlayCount { get; set; }
    public long TrackUpdateTime { get; set; }
    public int SpecialType { get; set; }
    public long TotalDuration { get; set; }
    public Creator? Creator { get; set; }
    public List<Creator>? Subscribers { get; set; }
    public bool? Subscribed { get; set; }
    public List<Song> Tracks { get; set; } = new List<Song>();
    public List<TrackId> TrackIds { get; set; } = new List<TrackId>();
    public string? CommentThreadId { get; set; }
    public bool NewImported { get; set; }
    public int AdType { get; set; }
    public bool HighQuality { get; set; }
    public int Privacy { get; set; }
    public bool Ordered { get; set; }
    public bool Anonimous { get; set; }
    public int CoverStatus { get; set; }
    public RecommendInfo? RecommendInfo { get; set; }
    public int ShareCount { get; set; }
    public string? CoverImgId_str { get; set; }
    public string? Alg { get; set; }
    public long CommentCount { get; set; }

    public string Action { get; set; } = string.Empty;
    public string ActionType { get; set; } = string.Empty;
    public string RecommendText { get; set; } = string.Empty;

    public class TrackId
    {
        public long Id { get; set; }
        public int V { get; set; }
        public int T { get; set; }
        public long At { get; set; }
        public string? Alg { get; set; }
        public long Uid { get; set; }
        public string? RcmdReason { get; set; }
        public string? Sc { get; set; }
    }

    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public List<string> Alias { get; set; } = new List<string>();
    }

    public class Album
    {
        public long Id { get; set; }
        public string Name { get; set; } = null!;
        public string PicUrl { get; set; } = null!;
    }
}