namespace NeteaseCloudMusicApi.Requests;

/// <param name="Limit"><inheritdoc/></param>
/// <param name="Offset"><inheritdoc/></param>
/// <param name="Cat"> 类别 </param>
public record TopPlaylistRequest(int? Limit, int? Offset, [property: AliasAs("cat")] string? Cat) : PagedRequestBase(Limit, Offset)
{
    /// <summary>
    /// 排序 now hot(默认)
    /// </summary>
    [AliasAs("order")]
    public string? Order { get; set; } = "now";
}