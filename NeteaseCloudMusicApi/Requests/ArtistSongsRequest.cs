namespace NeteaseCloudMusicApi.Requests;

/// <param name="Limit"><inheritdoc/></param>
/// <param name="Offset"><inheritdoc/></param>
/// <param name="Id"> 歌手Id </param>
public record ArtistSongsRequest(int? Limit, int? Offset, [property: AliasAs("id")] long Id) : PagedRequestBase(Limit, Offset)
{
    /// <summary>
    /// hot ,time 按照热门或者时间排序
    /// </summary>
    [AliasAs("order")]
    public string Order { get; set; } = "hot";

    public ArtistSongsRequest(long id) : this(null, null, id)
    {
    }
}