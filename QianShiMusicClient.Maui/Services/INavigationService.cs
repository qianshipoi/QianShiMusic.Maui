namespace QianShiMusicClient.Maui.Services
{
    public interface INavigationService
    {
        Task GoToLoginByEmailPageAsync();
        Task GoToLoginByPhonePageAsync();
        Task GoToLoginPageAsync();
        Task PushModelAsync(Page page);
    }
}