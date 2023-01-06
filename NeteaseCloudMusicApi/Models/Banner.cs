namespace NeteaseCloudMusicApi.Models;

public class Banner
{
    public string Pic { get; set; } = null!;
    public long TargetId { get; set; }
    public object? Adid { get; set; }
    public int TargetType { get; set; }
    public string TitleColor { get; set; } = null!;
    public string TypeTitle { get; set; } = null!;
    public string? Url { get; set; }
    public string? AdurlV2 { get; set; }
    public bool Exclusive { get; set; }
    public object? MonitorImpress { get; set; }
    public object? MonitorClick { get; set; }
    public object? MonitorType { get; set; }
    public List<object> MonitorImpressList { get; set; } = new();
    public List<object> MonitorClickList { get; set; } = new();
    public object? MonitorBlackList { get; set; }
    public object? ExtMonitor { get; set; }
    public object? ExtMonitorInfo { get; set; }
    public object? AdSource { get; set; }
    public object? AdLocation { get; set; }
    public string EncodeId { get; set; } = null!;
    public object? Program { get; set; }
    public object? Event { get; set; }
    public object? Video { get; set; }
    public object? DynamicVideoData { get; set; }
    public Song? Song { get; set; }
    public string BannerId { get; set; } = null!;
    public string Alg { get; set; } = null!;
    public string Scm { get; set; } = null!;
    public string RequestId { get; set; } = null!;
    public bool ShowAdTag { get; set; }
    public object? Pid { get; set; }
    public object? ShowContext { get; set; }
    public object? AdDispatchJson { get; set; }

    [JsonPropertyName("s_ctrp")]
    public string SCtrp { get; set; } = null!;
    public object? LogContext { get; set; }
    public string BannerBizType { get; set; } = null!;
}