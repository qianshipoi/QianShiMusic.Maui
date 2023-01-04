namespace NeteaseCloudMusicApi.Responses;

public class SearchHotDetailResponse : BaseResponse
{
    public string Message { get; set; } = default!;

    [JsonPropertyName("data")]
    public Data Result { get; set; } = new();

    public class Data
    {
        public string SearchWord { get; set; } = default!;
        public int Score { get; set; }
        public string Content { get; set; } = default!;
        public int Source { get; set; }
        public int IconType { get; set; }
        public string IconUrl { get; set; } = default!;
        public string Url { get; set; } = string.Empty;
        public string Alg { get; set; } = default!;
    }
}