using UseNotify.Entities;

namespace UseNotify.Services;

public interface INotificationService {
    Task SendNotificationAsync(Notification notification);
    Task<List<Notification>> GetNotifications();
}
