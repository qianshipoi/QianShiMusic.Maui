namespace NeteaseCloudMusicApi.Responses;

public class SearchResponse : BaseResponse
{
    public dynamic Result { get; set; } = default!;
}
public class SearchResponse<T> : SearchResponse where T : ISearchResultBase
{
    public new T Result { get; set; } = default!;
}

public interface ISearchResultBase
{ }

public record SongSearchResult : ISearchResultBase
{
    public bool HasMore { get; set; }
    public int SongCount { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
}

public record AlbumSearchResult : ISearchResultBase
{
    public int AlbumCount { get; set; }
    public List<Album> Albums { get; set; } = new();
}

public record ArtistSearchResult : ISearchResultBase
{
    public int ArtistCount { get; set; }
    public bool HasMore { get; set; }
    public dynamic? SearchQcReminder { get; set; }
    public List<Artist> Artists { get; set; } = new();
}

public record PlaylistSearchResult : ISearchResultBase
{
    public bool HasMore { get; set; }
    public int PlaylistCount { get; set; }
    public dynamic? SearchQcReminder { get; set; }
    public List<Playlist> Playlists { get; set; } = new();
}

public record MovieVideoSearchResult : ISearchResultBase
{
    [JsonPropertyName("mvCount")]
    public int MovieVideoCount { get; set; }
    [JsonPropertyName("mvs")]
    public List<MovieVideo>? MovieVideos { get; set; }
}