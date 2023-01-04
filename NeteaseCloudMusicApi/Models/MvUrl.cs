namespace NeteaseCloudMusicApi.Models;

public class MvUrl
{
    public int Code { get; set; }
    public long Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public int R { get; set; }
    public int Size { get; set; }
    public string Md5 { get; set; } = string.Empty;
    public int Expi { get; set; }
    public int Fee { get; set; }
    public int MvFee { get; set; }
    public int St { get; set; }
    public object? PromotionVo { get; set; }
    public string Msg { get; set; } = string.Empty;
}