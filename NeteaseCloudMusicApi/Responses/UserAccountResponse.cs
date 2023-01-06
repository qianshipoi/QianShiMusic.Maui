namespace NeteaseCloudMusicApi.Responses;

public class UserAccountResponse
{
    public int Code { get; set; }
    public Account? Account { get; set; }
    public Profile? Profile { get; set; }
}