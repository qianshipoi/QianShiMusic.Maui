namespace NeteaseCloudMusicApi.Requests;

/// <param name="Limit"><inheritdoc/></param>
/// <param name="Offset"><inheritdoc/></param>
/// <param name="Id"> 歌手ID </param>
public record ArtistAlbumRequest(int? Limit, int? Offset, [property: AliasAs("id")] long Id) : PagedRequestBase(Limit, Offset)
{
    public ArtistAlbumRequest(long id) : this(null, null, id)
    {
    }
}
