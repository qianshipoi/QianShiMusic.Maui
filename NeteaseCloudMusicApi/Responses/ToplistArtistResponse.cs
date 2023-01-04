namespace NeteaseCloudMusicApi.Responses;

public class ToplistArtistResponse : BaseResponse
{
    public ToplistArtist List { get; set; } = new ToplistArtist();

    public class ToplistArtist
    {
        public List<Artist> Artists { get; set; } = new List<Artist>();
        public long UpdateTime { get; set; }

        public int Type { get; set; }
    }
}