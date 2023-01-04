namespace NeteaseCloudMusicApi.Responses;

public class SearchHotResponse :BaseResponse
{
    public Data Result { get; set; } = new Data();

    public class Data
    {
        public List<Hot> Hots { get; set; } = new List<Hot>();
    }

    public class Hot
    {
        public string First { get; set; } = default!;
        public int Second { get; set; }
        public dynamic? Third { get; set; }
        public int IconType { get; set; }
    }
}