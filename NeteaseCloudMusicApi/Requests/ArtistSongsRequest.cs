namespace NeteaseCloudMusicApi.Requests;

public class ArtistSongsRequest: PagedRequestBase
{
    /// <param name="Id"> 歌手Id </param>
    [AliasAs("id")]
    public long Id { get; set; }
    /// <summary>
    /// hot ,time 按照热门或者时间排序
    /// </summary>
    [AliasAs("order")]
    public string Order { get; set; } = "hot";

    public ArtistSongsRequest(long id)
    {
        Id = id;
    }

}