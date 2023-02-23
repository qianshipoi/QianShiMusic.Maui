namespace NeteaseCloudMusicApi.Requests;

public class PagedRequestBase
{
    /// <param name="Limit"> 返回数量 </param>
    [AliasAs("limit")]
    public int? Limit { get; set; }

    /// <param name="Offset"> 偏移量 </param>
    [AliasAs("offset")]
    public int? Offset { get; set; }

    /// <summary> 时间戳 清除缓存 <summary>
    [AliasAs("time")]
    public long? Time { get; set; }

    public PagedRequestBase()
    {
    }

    public PagedRequestBase(int? limit)
    {
        Limit = limit;
    }

    public PagedRequestBase(long? time)
    {
        Time = time;
    }

    public PagedRequestBase(int? limit, long? time)
    {
        Limit = limit;
        Time = time;
    }

    public PagedRequestBase(int? limit = null, int? offset = null, long? time = null)
    {
        Limit = limit;
        Offset = offset;
        Time = time;
    }
}
