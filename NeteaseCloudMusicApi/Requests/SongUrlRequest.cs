namespace NeteaseCloudMusicApi.Requests;

public class SongUrlRequest : BaseRequest
{
    /// <summary>
    /// 音乐 ids
    /// </summary>
    [AliasAs("id")]
    public string Ids { get; set; } = default!;

    /// <summary>
    /// 码率,默认设置了 999000 即最大码率,如果要 320k 则可设置为 320000,其他类推
    /// </summary>
    [AliasAs("br")]
    public int? Br { get; set; }
}