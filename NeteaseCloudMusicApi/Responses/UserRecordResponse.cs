namespace NeteaseCloudMusicApi.Responses;

public class UserRecordResponse : BaseResponse
{
    public List<PlayRecord> WeekData { get; set; } = new();
    public List<PlayRecord> AllData { get; set; } = new();
}