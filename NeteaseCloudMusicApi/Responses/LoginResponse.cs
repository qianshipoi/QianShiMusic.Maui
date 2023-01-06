namespace NeteaseCloudMusicApi.Responses;

public class LoginResponse : BaseResponse
{
    public int LoginType { get; set; }
    public string? Token { get; set; }
    public Account Account { get; set; } = default!;
    public Profile Profile { get; set; } = default!;
    public string? Cookie { get; set; }
    public List<Binding>? Bindings { get; set; }

    public record Binding
    {
        public long UserId { get; set; }
        public string? Url { get; set; }
        public bool Expired { get; set; }
        public long BindingTime { get; set; }
        public string? TokenJsonStr { get; set; }
        public long ExpiresIn { get; set; }
        public long RefreshTime { get; set; }
        public long Id { get; set; }
        public long Type { get; set; }
    }
}
