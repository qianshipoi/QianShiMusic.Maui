namespace NeteaseCloudMusicApi;

public static class ApiClient
{
    static bool isInit = false;

    public static string? BaseUrl { get; private set; }

    public static CookieContainer? CookieContainer { get; private set; }

    private static Lazy<IMusicService> instance = new Lazy<IMusicService>(() =>
    {
        var handler = new HttpClientHandler();
        handler.CookieContainer = CookieContainer ?? throw new ArgumentNullException(nameof(CookieContainer));
        var client = new HttpClient(handler);
        client.BaseAddress = new Uri(BaseUrl ?? throw new ArgumentNullException(nameof(BaseUrl)));
        return RestService.For<IMusicService>(client);
    });

    public static IMusicService Current => instance.Value;

    public static string GetCookieString()
    {
        return JsonSerializer.Serialize(CookieContainer?.GetAllCookies().Select(x => new CookieInfo(x)));
    }

    public static void Init(string baseUrl, string? cookieStr = null)
    {
        if (isInit) return;
        isInit = true;

        BaseUrl = baseUrl;
        CookieContainer = new CookieContainer();
        if (!string.IsNullOrWhiteSpace(cookieStr))
        {
            var cookies = JsonSerializer.Deserialize<List<CookieInfo>>(cookieStr);
            if (cookies?.Count > 0)
            {
                var collection = new CookieCollection();
                foreach (var item in cookies)
                {
                    collection.Add(item.ToCookie());
                }
                CookieContainer?.Add(collection);
            }
        }
    }
}
