using UseNotify.Entities;

namespace UseNotify.Services;

public interface INotificationService {
    Task<Notification> SendNotificationAsync(Notification notification);
    Task<List<Notification>> GetNotifications();
}
