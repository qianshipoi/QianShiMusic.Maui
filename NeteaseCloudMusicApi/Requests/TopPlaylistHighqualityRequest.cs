﻿namespace NeteaseCloudMusicApi.Requests;

public class TopPlaylistHighqualityRequest : BaseRequest
{
    /// <summary>
    /// 分页参数,取上一页最后一个歌单的 updateTime 获取下一页数据
    /// </summary>
    [AliasAs("before")]
    public long? Before { get; set; }

    /// <summary>
    /// 取出歌单数量 , 默认为 20
    /// </summary>
    [AliasAs("limit")]
    public int? Limit { get; set; }

    /// <summary>
    ///  tag, 比如 " 华语 "、" 古风 " 、" 欧美 "、" 流行 ", 默认为 "全部",可从精品歌单标签列表接口获取(/playlist/highquality/tags)
    /// </summary>
    [AliasAs("cat")]
    public string? Cat { get; set; }
}