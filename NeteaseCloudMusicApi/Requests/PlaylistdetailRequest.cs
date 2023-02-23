namespace NeteaseCloudMusicApi.Requests;

public class PlaylistdetailRequest : BaseRequest
{
    /// <summary>
    /// 歌单 id
    /// </summary>
    [AliasAs("id")]
    public long Id { get; set; }

    public PlaylistdetailRequest(long id)
    {
        Id = id;
    }

    public PlaylistdetailRequest(long id, long time)
    {
        Id = id;
        Time = time;
    }
}