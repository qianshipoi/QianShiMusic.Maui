namespace NeteaseCloudMusicApi.Responses;

public class UserSubcountResponse : BaseResponse
{
    public int ProgramCount { get; set; }
    public int DjRadioCount { get; set; }
    public int MvCount { get; set; }
    public int ArtistCount { get; set; }
    public int NewProgramCount { get; set; }
    public int CreateDjRadioCount { get; set; }
    public int CreatedPlaylistCount { get; set; }
    public int SubPlaylistCount { get; set; }
}
