using CommunityToolkit.Maui.Alerts;

using QianShiMusic.IServices;

namespace QianShiMusic.Services
{
    public class NotificationService : INotificationService
    {
        public Task Show(string message)
        {
            return Toast.Make(message).Show();
        }
    }
}
