namespace NeteaseCloudMusicApi.Requests;

public class MvUrlRequest
{ /// <summary>
  /// mv id
  /// </summary>
    [AliasAs("id")]
    public long Id { get; set; }

    public MvUrlRequest(long id)
    {
        Id = id;
    }

    /// <summary>
    /// 分辨率,默认 1080,可从 /mv/detail 接口获取分辨率列表
    /// </summary>
    [AliasAs("r")]
    public int? R { get; set; } = 1080;
}