namespace NeteaseCloudMusicApi.Responses;

public class UserCloudResponse : BaseResponse
{
    public int Count { get; set; }
    public bool HasMore { get; set; }
    public string MaxSize { get; set; } = default!;
    public string Size { get; set; } = default!;
    public int UpgradeSign { get; set; }
    public List<CloudItem> Data { get; set; } = default!;
}