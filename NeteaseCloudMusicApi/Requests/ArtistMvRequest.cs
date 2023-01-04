namespace NeteaseCloudMusicApi.Requests;

/// <param name="Limit"><inheritdoc/></param>
/// <param name="Offset"><inheritdoc/></param>
/// <param name="Id"> 歌手Id </param>
public record ArtistMvRequest(int? Limit, int? Offset, [property: AliasAs("id")] long Id) : PagedRequestBase(Limit, Offset)
{
    public ArtistMvRequest(long id) : this(null, null, id)
    {
    }
}