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
            var response = await _musicService.LoginStatus(new Requests.BaseRequest()
            {
                Time = DateTime.Now.Ticks
            });
            Assert.Equal(200, response.Data.Code);
            Assert.NotNull(response.Data.Account);
            Assert.NotNull(response.Data.Profile);
        }
    }
}