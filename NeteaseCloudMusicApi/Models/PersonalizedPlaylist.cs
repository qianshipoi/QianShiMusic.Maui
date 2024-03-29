﻿namespace NeteaseCloudMusicApi.Models;

public partial class PersonalizedPlaylist
{
    public long Id { get; set; }
    public int Type { get; set; }
    public string Name { get; set; } = null!;
    public string Copywriter { get; set; } = null!;
    public string PicUrl { get; set; } = null!;
    public bool CanDislike { get; set; }
    public long PlayCount { get; set; }
    public bool HighQuality { get; set; }
}