namespace NeteaseCloudMusicApi.Requests;

public class LoginQrCheckRequest :BaseRequest
{
    [AliasAs("key")]
    public string Key { get; set; }

    public LoginQrCheckRequest(string key, long? time = null) : base(time)
    {
        Key = key;
    }
}