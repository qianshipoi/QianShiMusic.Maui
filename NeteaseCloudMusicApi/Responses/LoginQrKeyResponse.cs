namespace NeteaseCloudMusicApi.Responses;

public class LoginQrKeyResponse : BaseResponse
{
    public Result Data { get; set; } = null!;
    public record Result
    {
        public int Code { get; set; }
        public string Unikey { get; set; } = null!;
    }
}