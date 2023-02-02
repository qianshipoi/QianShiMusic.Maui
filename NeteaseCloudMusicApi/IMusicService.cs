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
}
