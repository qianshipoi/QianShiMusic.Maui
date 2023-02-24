namespace NeteaseCloudMusicApi;

public interface IMusicService
{
    [Get("/banner")]
    Task<BannerResponse> Banner(BannerRequest request, CancellationToken cancellationToken = default);

    [Get("/personalized")]
    Task<PersonalizedResponse> Personalized(PersonalizedRequest? request = null, CancellationToken cancellationToken = default);

    [Post("/login/cellphone")]
    Task<LoginResponse> LoginCellphone([Body(BodySerializationMethod.UrlEncoded)] LoginCellphoneRequest request, CancellationToken cancellationToken = default);

    [Post("/login")]
    Task<LoginResponse> Login([Body(BodySerializationMethod.UrlEncoded)] LoginRequest request, CancellationToken cancellationToken = default);

    [Get("/login/qr/key")]
    Task<LoginQrKeyResponse> LoginQrKey(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/login/qr/create")]
    Task<LoginQrCreateResponse> LoginQrCreate(LoginQrCreateRequest request, CancellationToken cancellationToken = default);

    [Get("/login/qr/check")]
    Task<LoginQrCheckResponse> LoginQrCheck(LoginQrCheckRequest request, CancellationToken cancellationToken = default);

    [Get("/artist/album")]
    Task<ArtistAlbumResponse> ArtistAlbum(ArtistAlbumRequest request, CancellationToken cancellationToken = default);

    [Get("/login/status")]
    Task<LoginStatusResponse> LoginStatus(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/user/account")]
    Task<UserAccountResponse> UserAccount(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/user/subcount")]
    Task<UserSubcountResponse> UserSubcount(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/user/level")]
    Task<UserLevelResponse> UserLevel(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/countries/code/list")]
    Task<CountriesCodeListResponse> CountriesCodeList(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/user/playlist")]
    Task<UserPlaylistResponse> UserPlaylsit(UserPlaylistRequest request, CancellationToken cancellationToken = default);

    [Get("/user/detail")]
    Task<UserDetailResponse> UserDetail(UserDetailRequest request, CancellationToken cancellationToken = default);

    [Get("/captcha/sent")]
    Task<CaptchaSentResponse> CaptchaSent(CaptchaSentRequest request, CancellationToken cancellationToken = default);

    [Get("/logout")]
    Task<BaseResponse> Logout(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/playlist/hot")]
    Task<PlaylistHotResponse> PlaylistHot(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/playlist/Catlist")]
    Task<PlaylistCatlistResponse> PlaylistCatlist(BaseRequest? request = null, CancellationToken cancellationToken = default);

    [Get("/top/playlist")]
    Task<TopPlaylistResponse> TopPlaylist(TopPlaylistRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取歌单详情
    /// </summary>
    /// <param name="requst"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/playlist/detail")]
    Task<PlaylistDetailResponse> PlaylistDetail(PlaylistdetailRequest requst, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse> Cloudsearch(SearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索单曲
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse<SongSearchResult>> SongSearch(SongSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索专辑
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse<AlbumSearchResult>> AlbumSearch(AlbumSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索作者
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse<ArtistSearchResult>> ArtistSearch(ArtistSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索歌单
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse<PlaylistSearchResult>> PlaylistSearch(PlaylistSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 搜索MV
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/cloudsearch")]
    Task<SearchResponse<MovieVideoSearchResult>> MvSearch(MvSearchRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// 获取歌单所有歌曲
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    [Get("/playlist/track/all")]
    Task<PlaylistTrackAllResponse> PlaylistTrackAll(PlaylistTrackAllRequest request, CancellationToken cancellationToken = default);
}
