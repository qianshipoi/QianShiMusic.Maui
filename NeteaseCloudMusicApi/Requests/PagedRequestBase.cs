namespace NeteaseCloudMusicApi.Requests;


/// <param name="Limit"> 返回数量 </param>
/// <param name="Offset"> 偏移量 </param>
public record PagedRequestBase([property: AliasAs("limit")] int? Limit, [property: AliasAs("offset")] int? Offset);
