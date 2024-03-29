﻿namespace NeteaseCloudMusicApi.Models;

public class CloudItem
{
    public long AddTime { get; set; }
    public string Album { get; set; } = default!;
    public string Artist { get; set; } = default!;
    public int Bitrate { get; set; }
    public long Cover { get; set; }
    public string CoverId { get; set; } = default!;
    public string FileName { get; set; } = default!;
    public long FileSize { get; set; }
    public string LyricId { get; set; } = default!;
    public long SongId { get; set; }
    public string SongName { get; set; } = default!;
    public int Version { get; set; }
    public Song SimpleSong { get; set; } = default!;
}