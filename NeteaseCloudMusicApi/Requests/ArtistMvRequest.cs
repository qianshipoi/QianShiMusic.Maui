namespace NeteaseCloudMusicApi.Requests;

public class ArtistMvRequest: PagedRequestBase
{
    /// <param name="Id"> 歌手Id </param>
    [AliasAs("id")]
    public long Id { get; set; }
    public ArtistMvRequest(long id)
    {
        Id = id;
    }
}