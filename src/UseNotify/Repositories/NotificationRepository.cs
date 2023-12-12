using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UseNotify.Entities;

namespace UseNotify.Repositories;

public class NotificationRepository<TDbContext> : INotificationRepository where TDbContext : DbContext {

    private readonly TDbContext _dbContext;
    private DbSet<Notification> Notifications { get; set; }

    public NotificationRepository(TDbContext dbContext) {
        _dbContext = dbContext;
        Notifications = _dbContext.Set<Notification>();
    }

    public async Task AddNotificationAsync(Notification notification) {
        await _dbContext.AddAsync(notification);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Notification>> GetNotificationsAsync() {
        return await Notifications.ToListAsync();
    }
}
