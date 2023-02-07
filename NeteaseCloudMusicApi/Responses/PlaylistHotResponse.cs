namespace NeteaseCloudMusicApi.Responses;

public class PlaylistHotResponse : BaseResponse
{
    public List<Tag> Tags { get; set; } = new List<Tag>();
}


public class PlaylistCatlistResponse : BaseResponse
{

    public Cat All { get; set; } = null!;

    public List<Cat> Sub { get; set; } = null!;

    public Dictionary<int, string> Categories { get; set; } = null!;

    public class Cat
    {
        public string Name { get; set; } = null!;
        public int ResourceCount { get; set; }
        public int ImgId { get; set; }
        public string? ImgUrl { get; set; }
        public int Type { get; set; }
        public int Category { get; set; }
        public int ResourceType { get; set; }
        public bool Hot { get; set; }
        public bool Activity { get; set; }
    }
}