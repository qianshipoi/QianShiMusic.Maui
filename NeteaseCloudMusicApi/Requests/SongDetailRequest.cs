namespace NeteaseCloudMusicApi.Requests;

public class SongDetailRequest : BaseRequest
{
    /// <summary>
    /// 音乐 ids
    /// </summary>
    [AliasAs("ids")]
    public string Ids { get; set; } = default!;

    public SongDetailRequest(string ids)
    {
        Ids = ids;
    }
}
