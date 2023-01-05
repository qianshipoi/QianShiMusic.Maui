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

    [Get("/artist/album")]
    Task<ArtistAlbumResponse> ArtistAlbum(ArtistAlbumRequest request, CancellationToken cancellationToken = default);

    [Get("/login/status")]
    Task<LoginStatusResponse> LoginStatus(BaseRequest? request = null, CancellationToken cancellationToken = default);
}
