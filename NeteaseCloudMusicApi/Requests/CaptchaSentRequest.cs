namespace NeteaseCloudMusicApi.Requests;

public class CaptchaSentRequest : BaseRequest
{
    [AliasAs("phone")]
    public string Phone { get; set; }
    public CaptchaSentRequest(string phone)
    {
        Phone = phone;
    }
}
