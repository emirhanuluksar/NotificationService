using Microsoft.AspNetCore.SignalR;
using UseNotify.Entities;
using UseNotify.Hubs;
using UseNotify.Repositories;

namespace UseNotify.Services;

public class NotificationManager : INotificationService {
    private readonly IHubContext<NotificationHub> _hubContext;
    private readonly INotificationRepository _notificationRepository;

    public NotificationManager(IHubContext<NotificationHub> hubContext, INotificationRepository notificationRepository) {
        _hubContext = hubContext;
        _notificationRepository = notificationRepository;
    }

    public async Task<List<Notification>> GetNotifications() {
        var notifications = await _notificationRepository.GetNotificationsAsync();
        return notifications.ToList();
    }

    public async Task SendNotificationAsync(Notification notification) {
        await _hubContext.Clients.All.SendAsync("ReceiveNotification", notification);
        await _notificationRepository.AddNotificationAsync(notification);
    }
}
