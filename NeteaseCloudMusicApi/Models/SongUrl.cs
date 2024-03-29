﻿namespace NeteaseCloudMusicApi.Models;

public class SongUrl
{
    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; } = default!;

    [JsonPropertyName("br")]
    public int Br { get; set; }

    [JsonPropertyName("size")]
    public int Size { get; set; }

    [JsonPropertyName("md5")]
    public string? Md5 { get; set; }

    [JsonPropertyName("code")]
    public int Code { get; set; }

    [JsonPropertyName("expi")]
    public int Expi { get; set; }

    [JsonPropertyName("type")]
    public string? Type { get; set; }

    [JsonPropertyName("gain")]
    public double Gain { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }

    [JsonPropertyName("uf")]
    public dynamic? Uf { get; set; }

    [JsonPropertyName("payed")]
    public int Payed { get; set; }

    [JsonPropertyName("flag")]
    public int Flag { get; set; }

    [JsonPropertyName("canExtend")]
    public bool CanExtend { get; set; }

    [JsonPropertyName("freeTrialInfo")]
    public dynamic? FreeTrialInfo { get; set; }

    [JsonPropertyName("level")]
    public string? Level { get; set; }

    [JsonPropertyName("encodeType")]
    public string? EncodeType { get; set; }

    [JsonPropertyName("freeTrialPrivilege")]
    public FreeTrialPrivilege? FreeTrialPrivilege { get; set; }

    [JsonPropertyName("freeTimeTrialPrivilege")]
    public FreeTimeTrialPrivilege? FreeTimeTrialPrivilege { get; set; }

    [JsonPropertyName("urlSource")]
    public int UrlSource { get; set; }
}

public class FreeTimeTrialPrivilege
{
    [JsonPropertyName("resConsumable")]
    public bool ResConsumable { get; set; }

    [JsonPropertyName("userConsumable")]
    public bool UserConsumable { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("remainTime")]
    public int RemainTime { get; set; }
}

public class FreeTrialPrivilege
{
    [JsonPropertyName("resConsumable")]
    public bool ResConsumable { get; set; }

    [JsonPropertyName("userConsumable")]
    public bool UserConsumable { get; set; }

    [JsonPropertyName("listenType")]
    public dynamic? ListenType { get; set; }
}