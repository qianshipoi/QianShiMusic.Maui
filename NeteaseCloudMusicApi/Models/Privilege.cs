namespace NeteaseCloudMusicApi.Models;

public class Privilege
{
    [JsonPropertyName("cp")]
    public int Cp { get; set; }

    [JsonPropertyName("cs")]
    public bool Cs { get; set; }

    [JsonPropertyName("dl")]
    public int Dl { get; set; }

    [JsonPropertyName("fee")]
    public int Fee { get; set; }

    [JsonPropertyName("fl")]
    public int Fl { get; set; }

    [JsonPropertyName("flag")]
    public int Flag { get; set; }

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("maxbr")]
    public int Maxbr { get; set; }

    [JsonPropertyName("payed")]
    public int Payed { get; set; }

    [JsonPropertyName("pl")]
    public int Pl { get; set; }

    [JsonPropertyName("preSell")]
    public bool PreSell { get; set; }

    [JsonPropertyName("sp")]
    public int Sp { get; set; }

    [JsonPropertyName("st")]
    public int St { get; set; }

    [JsonPropertyName("subp")]
    public int Subp { get; set; }

    [JsonPropertyName("toast")]
    public bool Toast { get; set; }
}