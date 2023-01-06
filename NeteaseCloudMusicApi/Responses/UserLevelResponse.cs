namespace NeteaseCloudMusicApi.Responses;

public class UserLevelResponse : BaseResponse
{
    public bool Full { get; set; }

    public UserLevelData Data { get; set; } = default!;

    public class UserLevelData
    {
        public int UserId { get; set; }
        public string? Info { get; set; }
        public double Progress { get; set; }
        public int NextPlayCount { get; set; }
        public int NextLoginCount { get; set; }
        public int NowPlayCount { get; set; }
        public int NowLoginCount { get; set; }
        public int Level { get; set; }
    }
}
