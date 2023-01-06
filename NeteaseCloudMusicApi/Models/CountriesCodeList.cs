namespace NeteaseCloudMusicApi.Models;

public class CountriesCodeList
{
    public string Label { get; set; } = null!;

    public List<Country> CountryList { get; set; } = default!;
}
