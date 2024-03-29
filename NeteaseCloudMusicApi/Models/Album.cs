﻿namespace NeteaseCloudMusicApi.Models;

public class Album
{
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string Type { get; set; } = null!;
    public int Size { get; set; }

    [JsonPropertyName("picUrl")]
    public string CoverImgUrl { get; set; } = null!;

    public string AliasAs { get; set; } = null!;
    public string Tags { get; set; } = null!;
    public Artist Artist { get; set; } = new();
    public List<Artist> Artists { get; set; } = new();
    public long PublishTime { get; set; }
    public string Alg { get; set; } = string.Empty;
    public List<string> Alias { get; set; } = new();
    public string BlurPicUrl { get; set; } = string.Empty;
    public string? BriefDesc { get; set; }
    public string? CommentThreadId { get; set; }
    public string Company { get; set; } = string.Empty;
    public long CompanyId { get; set; }
    public string ContainedSong { get; set; } = string.Empty;
    public long CopyrightId { get; set; }
    public int Mark { get; set; }
    public bool OnSale { get; set; }
    public bool Paid { get; set; }
    public long PicId { get; set; }
    public List<Song>? Songs { get; set; }
    public int Status { get; set; }
    public List<string> Tns { get; set; } = new();
    public List<string> Msg { get; set; } = new();
    public long SubTime { get; set; }
    public List<string> TransNames { get; set; } = new();
}