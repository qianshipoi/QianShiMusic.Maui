namespace NeteaseCloudMusicApi.Requests;

/// <summary>
/// 获取歌单所有歌曲
/// </summary>
public class PlaylistTrackAllRequest : PagedRequestBase
{
    /// <summary>
    /// 歌单 id
    /// </summary>
    [AliasAs("id")]
    public long Id { get; set; }

    public PlaylistTrackAllRequest(long id, int limit = 30) : base(limit)
    {
        Id = id;
    }
}
