namespace NeteaseCloudMusicApi.Responses;

public class LoginQrCreateResponse
{
    public int Code { get; set; }

    public Result Data { get; set; } = null!;

    public record Result
    {
        public string Qrurl { get; set; } = string.Empty;

        public string Qrimg { get; set; } = string.Empty;
    }
}