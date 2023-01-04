namespace NeteaseCloudMusicApi.Models;

public record Account
{
    public long Id { get; set; }
    public bool AnonimousUser { get; set; }
    public int Ban { get; set; }
    public long BaoyueVersion { get; set; }
    public long DonateVersion { get; set; }
    public long CreateTime { get; set; }
    public bool PaidFee { get; set; }
    public int Status { get; set; }
    public long TokenVersion { get; set; }
    public int Type { get; set; }
    public string UserName { get; set; } = default!;
    public int VipType { get; set; }
    public int WhitelistAuthority { get; set; }
}