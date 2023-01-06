namespace NeteaseCloudMusicApi.Responses;

public class CountriesCodeListResponse : BaseResponse
{
    public List<CountriesCodeList> Data { get; set; } = default!;
}