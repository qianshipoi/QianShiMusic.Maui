namespace NeteaseCloudMusicApi.Responses;

public class LoginStatusResponse
{
    public LoginStatusData Data { get; set; } = default!;
    public record LoginStatusData
    {
        public int Code { get; set; }
        public Account? Account { get; set; }
        public Profile? Profile { get; set; }
    }
}