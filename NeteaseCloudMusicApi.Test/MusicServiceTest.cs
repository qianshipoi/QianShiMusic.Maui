using Refit;

using System;
using System.Net;
using System.Threading.Tasks;

using Xunit;
using Xunit.Abstractions;

namespace NeteaseCloudMusicApi.Test
{
    public class MusicServiceTest : TestBase
    {
        const string CookieString = "[{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/eapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/eapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/eapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/neapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/neapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/neapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/neapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/openapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/openapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/wapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/wapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/wapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/wapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/weapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/weapi/clientlog\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_R_T\",\"Value\":\"1579326623787\",\"Path\":\"/weapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_A_T\",\"Value\":\"1579326623757\",\"Path\":\"/weapi/feedback\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"__remember_me\",\"Value\":\"true\",\"Path\":\"/\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"__csrf\",\"Value\":\"37d41471820872940cec0c8f08ec84ea\",\"Path\":\"/\",\"Domain\":\"www.kuriyama.top\"},{\"Name\":\"MUSIC_U\",\"Value\":\"0091FAC82CCF08F5A7582BEEE0B7BE03E8966DB3CA720A355330DBD4EF8BF318BBA0B700D0113241BA36B97A351E15774A3E913990577AACEDEAFF2C6520422ADA0B6FA8B5F906AC4954622497325A09C33F81BE5D1259F5F899BF6863414AE19F3187F69185E64C8BF35C2B4C04566249B1A0440991B37D8E6BE3E4E8C1A6916C298D7F88562832F4E73E4E339C708257253F86D1879876E8BBB96EA8F991015A219B8BE57A4B14FEFB4D0205201D0E6E1C09A2B4BD53EDE1E5CF791CEE2DDE3ED75D687564034777C8E5D176398F8AA15A88D83AF12FF8DFEB0C5A526CF16DE7094887015546A0145D677380ACEE20D1E7D06C90E6D1BDDC96D4861233F58D3CD250F008C50EF733E6ACBEDF09B50E8F42998925F416A1A973695C7DCE4E9BC5\",\"Path\":\"/\",\"Domain\":\"www.kuriyama.top\"}]";

        readonly IMusicService _musicService;

        long Now => DateTime.Now.Ticks;

        public MusicServiceTest(ITestOutputHelper output) : base(output)
        {
            ApiClient.Init("https://www.kuriyama.top/music-api", CookieString);
            _musicService = ApiClient.Current;
        }

        [Fact]
        public async Task CallPersonalized()
        {
            var response = await _musicService.Personalized(new Requests.PersonalizedRequest() { Limit = 10 });

            Assert.NotNull(response);
            Assert.Equal(200, response.Code);
            Assert.Equal(10, response.Result.Count);
        }

        [Fact]
        public async Task CallArtistAlbum()
        {
            var limit = 12;
            var response = await _musicService.ArtistAlbum(new Requests.ArtistAlbumRequest(6452) { Limit = limit });

            Assert.NotNull(response);
            Assert.Equal(200, response.Code);
            Assert.Equal(limit, response.HotAlbums.Count);

            Output.WriteLine(ApiClient.GetCookieString());
        }

        [Fact]
        public async Task CallLoginStatus()
        {
            var response = await _musicService.LoginStatus(new Requests.BaseRequest(DateTime.Now.Ticks));
            Assert.Equal(200, response.Data.Code);
            Assert.NotNull(response.Data.Account);
            Assert.NotNull(response.Data.Profile);
        }

        [Fact]
        public async Task CallUserAccount()
        {
            var response = await _musicService.UserAccount(new Requests.BaseRequest(DateTime.Now.Ticks));
            Assert.Equal(200, response.Code);
            Assert.NotNull(response.Account);
            Assert.NotNull(response.Profile);
        }

        [Fact]
        public async Task CallBanner()
        {
            var response = await _musicService.Banner(new Requests.BannerRequest(1) { Time = DateTime.Now.Ticks });

            Assert.Equal(200, response.Code);
            Assert.NotEmpty(response.Banners);
        }

        [Fact]
        public async Task CallUserLevel()
        {
            var response = await _musicService.UserLevel(new Requests.BaseRequest(DateTime.Now.Ticks));

            Assert.Equal(200, response.Code);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public async Task CallUserSubcount()
        {
            var response = await _musicService.UserSubcount(new Requests.BaseRequest(DateTime.Now.Ticks));

            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task CallCountriesCodeList()
        {
            var response = await _musicService.CountriesCodeList(new Requests.BaseRequest(DateTime.Now.Ticks));

            Assert.Equal(200, response.Code);
            Assert.NotEmpty(response.Data);
        }

        [Fact]
        public async Task CallUserPlaylsit()
        {
            var response = await _musicService.UserPlaylsit(new Requests.UserPlaylistRequest(32953014));

            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task CallUserDetail()
        {
            var response = await _musicService.UserDetail(new Requests.UserDetailRequest(32953014));

            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task CallCaptchaSent()
        {
            var response = await _musicService.CaptchaSent(new Requests.CaptchaSentRequest("15926581437"));

            Assert.Equal(200, response.Code);
            Assert.True(response.Data);
        }

        [Fact]
        public async Task LoginQrCode()
        {
            var keyResponse = await _musicService.LoginQrKey(new Requests.BaseRequest(DateTime.Now.Ticks));

            Assert.Equal(200, keyResponse.Code);
            Assert.NotNull(keyResponse.Data);
            Assert.NotNull(keyResponse.Data.Unikey);

            var qrUrlResponse = await _musicService.LoginQrCreate(new Requests.LoginQrCreateRequest(keyResponse.Data.Unikey, true, DateTime.Now.Ticks));

            Assert.Equal(200, qrUrlResponse.Code);
            Assert.NotEmpty(qrUrlResponse.Data.Qrimg);
            Assert.NotEmpty(qrUrlResponse.Data.Qrurl);

            var checkResponse = await _musicService.LoginQrCheck(new Requests.LoginQrCheckRequest(keyResponse.Data.Unikey, DateTime.Now.Ticks));

            Assert.Equal(801, checkResponse.Code);
        }

        [Fact]
        public async Task PlaylistHot()
        {
            var response = await _musicService.PlaylistHot(new Requests.BaseRequest(Now));

            Assert.Equal(200, response.Code);
            Assert.NotNull(response.Tags);
        }

        [Fact]
        public async Task PlaylistCatlist()
        {
            var response = await _musicService.PlaylistCatlist(new Requests.BaseRequest(Now));

            Assert.Equal(200, response.Code);
            Assert.NotNull(response.Sub);
            Assert.NotNull(response.All);
            Assert.NotNull(response.Categories);
        }

        [Theory]
        [InlineData("官方")]
        [InlineData("华语")]
        [InlineData("ACG")]
        public async Task TopPlaylist(string cat)
        {
            var response = await _musicService.TopPlaylist(new Requests.TopPlaylistRequest(cat)
            {
                Time = Now
            });

            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task PlaylistDetail()
        {
            var response = await _musicService.PlaylistDetail(new Requests.PlaylistdetailRequest(24381616)
            {
                Time = Now
            });

            Assert.Equal(200, response.Code);
        }

        [Fact]
        public async Task Search()
        {
            var keywords = "海阔天空";
            {
                var response = await _musicService.Cloudsearch(new Requests.SearchRequest(keywords, 1));
                Assert.Equal(200, response.Code);
            }
            {
                var response = await _musicService.SongSearch(new Requests.SongSearchRequest(keywords));
                Assert.Equal(200, response.Code);
            }
            {
                var response = await _musicService.AlbumSearch(new Requests.AlbumSearchRequest(keywords));
                Assert.Equal(200, response.Code);
            }
            {
                var response = await _musicService.ArtistSearch(new Requests.ArtistSearchRequest(keywords));
                Assert.Equal(200, response.Code);
            }
            {
                var response = await _musicService.PlaylistSearch(new Requests.PlaylistSearchRequest(keywords));
                Assert.Equal(200, response.Code);
            }
            {
                var response = await _musicService.MvSearch(new Requests.MvSearchRequest(keywords));
                Assert.Equal(200, response.Code);
            }
        }

        [Fact]
        public async Task PlaylistTrackAll()
        {
            var response = await _musicService.PlaylistTrackAll(new Requests.PlaylistTrackAllRequest(24381616)
            {
                Time = DateTime.Now.Ticks
            });
            Assert.Equal(200, response.Code);
        }
    }
}