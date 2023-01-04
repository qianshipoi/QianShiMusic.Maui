namespace NeteaseCloudMusicApi.Responses;

public class RecommendSongsResponse : BaseResponse
{
    public Result Data { get; set; } = new Result();

    public class Result
    {
        public List<Song> DailySongs { get; set; } = new();
        public List<Song> OrderSongs { get; set; } = new();
        public List<(long songId, string reason)> RecommendReasons { get; set; } = new();
    }
}