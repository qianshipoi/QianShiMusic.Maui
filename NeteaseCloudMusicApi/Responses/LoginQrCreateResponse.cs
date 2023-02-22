namespace NeteaseCloudMusicApi.Responses;

public class LoginQrCreateResponse : BaseResponse
{
    public Result Data { get; set; } = null!;

    public record Result
    {
        public string Qrurl { get; set; } = string.Empty;

        public string? Qrimg { get; set; }
    }
}