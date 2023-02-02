namespace QianShiMusicClient.Maui.Services
{
    public interface INavigationService
    {
        Task GoToLoginByEmailPageAsync();
        Task GoToLoginByPhonePageAsync();
        Task GoToLoginByQrCodePageCommand();
        Task GoToLoginPageAsync();
        Task GoToPlaylistPageAsync();
        Task PushModelAsync(Page page);
    }
}