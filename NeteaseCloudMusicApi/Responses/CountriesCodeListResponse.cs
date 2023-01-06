namespace NeteaseCloudMusicApi.Responses;

public class CountriesCodeListResponse : BaseResponse
{
    public string Message { get; set; } = null!;

    public List<CountriesCodeList> Data { get; set; } = default!;
}