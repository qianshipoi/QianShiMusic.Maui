namespace NeteaseCloudMusicApi.Requests;

public record UserPlaylistRequest(int? Limit, int? Offset, [property: AliasAs("uid")] long Uid) : PagedRequestBase(Limit, Offset);