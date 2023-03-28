namespace NeteaseCloudMusicApi.Models;

public class TopSong
{
    public bool Starred { get; set; }
    public int Popularity { get; set; }
    public int StarredNum { get; set; }
    public int PlayedNum { get; set; }
    public int DayPlays { get; set; }
    public int HearTime { get; set; }
    public string Mp3Url { get; set; } = default!;
    public dynamic? RtUrls { get; set; }
    public Album Album { get; set; } = default!;
    public int Status { get; set; }
    public int Fee { get; set; }
    public Music? MMusic { get; set; }
    public Music? LMusic { get; set; }
    public Music? HMusic { get; set; }
    public Music? BMusic { get; set; }
    public Music? SqMusic { get; set; }
    public Music? HrMusic { get; set; }
    public string CopyFrom { get; set; } = string.Empty;
    public int Mvid { get; set; }
    public int Ftype { get; set; }
    public int Rtype { get; set; }
    public dynamic? Rurl { get; set; }
    public string CommentThreadId { get; set; } = default!;
    public int Score { get; set; }
    public dynamic? Crbt { get; set; }
    public dynamic? RtUrl { get; set; }
    public List<Artist> Artists { get; set; } = new();
    public List<string> Alias { get; set; } = new();
    public int CopyrightId { get; set; }
    public int Position { get; set; }
    public int Duration { get; set; }
    public dynamic? Audition { get; set; }
    public string Ringtone { get; set; } = string.Empty;
    public string Disc { get; set; } = default!;
    public int No { get; set; }
    public string Name { get; set; } = default!;
    public int Id { get; set; }
    public bool Exclusive { get; set; }
    public Privilege Privilege { get; set; } = default!;
    public List<string> TransNames { get; set; } = new();
    public string? RecommendReason { get; set; }
    public string? Alg { get; set; }
}

public class Music
{
    public int DfsId { get; set; }
    public int PlayTime { get; set; }
    public int VolumeDelta { get; set; }
    public int Sr { get; set; }
    public int Bitrate { get; set; }
    public string? Name { get; set; }
    public long Id { get; set; }
    public int Size { get; set; }
    public string Extension { get; set; } = default!;
}
