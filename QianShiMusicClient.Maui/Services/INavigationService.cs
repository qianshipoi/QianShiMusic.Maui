namespace QianShiMusicClient.Maui.Services
{
    public interface INavigationService
    {
        Task GoToLoginByEmailPageAsync();
        Task GoToLoginByPhonePageAsync();
        Task GoToLoginPageAsync();
        Task GoToPlaylistPageAsync();
        Task PushModelAsync(Page page);
    }
}