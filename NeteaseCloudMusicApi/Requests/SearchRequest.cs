namespace NeteaseCloudMusicApi.Requests;

public abstract class SeachBaseRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    [AliasAs("type")]
    public int Type { get; protected set; } = 1;

    public SeachBaseRequest(string keywords)
    {
        Keywords = keywords;
    }
}

public class SongSearchRequest : SeachBaseRequest
{
    public SongSearchRequest(string keywords) : base(keywords)
    {
        Type = 1;
    }
}

public class AlbumSearchRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    [AliasAs("type")]
    public int Type { get; } = 10;

    public AlbumSearchRequest(string keywords)
    {
        Keywords = keywords;
    }
}

public class ArtistSearchRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    [AliasAs("type")]
    public int Type { get; } = 100;

    public ArtistSearchRequest(string keywords)
    {
        Keywords = keywords;
    }
}

public class PlaylistSearchRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    [AliasAs("type")]
    public int Type { get; } = 1000;

    public PlaylistSearchRequest(string keywords)
    {
        Keywords = keywords;
    }
}

public class MvSearchRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    [AliasAs("type")]
    public int Type { get; } = 1004;

    public MvSearchRequest(string keywords)
    {
        Keywords = keywords;
    }
}

public class SearchRequest : PagedRequestBase
{
    [AliasAs("keywords")]
    public string Keywords { get; set; }

    /// <summary>
    /// 搜索类型；默认为 1 即单曲 , 取值意义 : 1: 单曲, 10: 专辑, 100: 歌手, 1000: 歌单, 1002: 用户, 1004: MV, 1006: 歌词, 1009: 电台, 1014: 视频, 1018:综合, 2000:声音(搜索声音返回字段格式会不一样)
    /// </summary>
    [AliasAs("type")]
    public int Type { get; set; } = 1;

    public SearchRequest(string keywords, int type)
    {
        Keywords = keywords;
        Type = type;
    }
}

public enum SearchType
{
    单曲 = 1,
    专辑 = 10,
    歌手 = 100,
    歌单 = 1000,
    用户 = 1002,
    MV = 1004,
    歌词 = 1006,
    电台 = 1009,
    视频 = 1014,
    综合 = 1018,
    声音 = 2000
}