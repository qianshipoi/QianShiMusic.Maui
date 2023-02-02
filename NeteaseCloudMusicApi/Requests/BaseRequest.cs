namespace NeteaseCloudMusicApi.Requests;

public class BaseRequest
{
    [AliasAs("time")]
    public long? Time { get; set; }

    public BaseRequest(long? time = null)
    {
        Time = time;
    }
}
