﻿namespace NeteaseCloudMusicApi;

public interface IMusicService
{
    [Get("/personalized")]
    Task<PersonalizedResponse> Personalized(PersonalizedRequest? request = null);

    [Post("/login/cellphone")]
    Task<LoginResponse> LoginCellphone([Body(BodySerializationMethod.UrlEncoded)] LoginCellphoneRequest request);

    [Get("/artist/album")]
    Task<ArtistAlbumResponse> ArtistAlbum(ArtistAlbumRequest request);

    [Get("/login/status")]
    Task<LoginStatusResponse> LoginStatus(BaseRequest? request = null);
}
