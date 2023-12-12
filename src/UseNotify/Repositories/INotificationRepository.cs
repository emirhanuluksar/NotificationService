using UseNotify.Entities;

namespace UseNotify.Repositories;

public interface INotificationRepository {
    Task AddNotificationAsync(Notification notification);
    Task<IEnumerable<Notification>> GetNotificationsAsync();
}
