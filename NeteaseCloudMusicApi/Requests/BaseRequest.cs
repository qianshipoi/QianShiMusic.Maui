namespace NeteaseCloudMusicApi.Requests;

public class BaseRequest
{
    [AliasAs("time")]
    public long? Time { get; set; }
}