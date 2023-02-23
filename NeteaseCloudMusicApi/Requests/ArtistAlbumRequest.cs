namespace NeteaseCloudMusicApi.Requests;

public class ArtistAlbumRequest : PagedRequestBase
{
    /// <param name="Id"> 歌手ID </param>
    [property: AliasAs("id")]
    public long Id { get; set; }

    public ArtistAlbumRequest(long id)
    {
        Id = id;
    }
}
