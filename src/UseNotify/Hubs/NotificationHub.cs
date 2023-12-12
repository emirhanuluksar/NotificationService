using Microsoft.AspNetCore.SignalR;
using UseNotify.Entities;

namespace UseNotify.Hubs;

public class NotificationHub : Hub {
    public async Task SendNotificationAsync(Notification notification) {
        await Clients.All.SendAsync("ReceiveNotification", notification);
    }
}
