namespace NeteaseCloudMusicApi.Models;

public class PlayRecord
{
    public int PlayCount { get; set; }
    public sbyte Score { get; set; }
    public Song Song { get; set; } = default!;
}