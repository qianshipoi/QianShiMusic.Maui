namespace NeteaseCloudMusicApi.Requests;

public class TopPlaylistRequest : PagedRequestBase
{
    /// <param name="Cat"> 类别 </param>
    [AliasAs("cat")]
    public string Cat { get; set; }

    /// <summary>
    /// 排序 now hot(默认)
    /// </summary>
    [AliasAs("order")]
    public string? Order { get; set; } = "now";
    public TopPlaylistRequest(string cat)
    {
        Cat = cat;
    }
}
