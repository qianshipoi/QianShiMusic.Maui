namespace NeteaseCloudMusicApi.Requests;

public class LoginQrCreateRequest : BaseRequest
{
    [AliasAs("key")]
    public string Key { get; set; }

    [AliasAs("qrimg")]
    public bool QrImg { get; set; }

    public LoginQrCreateRequest(string key, bool qrImg = false, long? time = null) : base(time)
    {
        Key = key;
        QrImg = qrImg;
    }
}
