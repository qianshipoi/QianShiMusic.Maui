namespace NeteaseCloudMusicApi.Responses;

public class RecommendResourceResponse : BaseResponse
{
    public bool FeatureFirst { get; set; }
    public bool HaveRcmdSongs { get; set; }
    public List<Playlist> Recommend { get; set; } = new();
}