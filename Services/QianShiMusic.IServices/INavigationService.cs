namespace QianShiMusic.IServices
{
    public interface INavigationService
    {
        Task GoToLoginByEmailPageAsync();
        Task GoToLoginByPhonePageAsync();
        Task GoToLoginByQrCodePageCommand();
        Task GoToLoginPageAsync();
        Task GoToPlaylistPageAsync();
    }
}
