namespace NeteaseCloudMusicApi.Responses;

public class BaseResponse
{
    public int Code { get; set; }
    public string? Msg { get; set; }
    public string? Message { get; set; }

    public string GetErrorMsg(string? defaultMsg = null)
    {
        return Msg ?? Message ?? defaultMsg ?? string.Empty;
    }
}