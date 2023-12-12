using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UseNotify.Entities;

namespace UseNotify.Repositories;

public class NotificationRepository<TDbContext> : RepositoryBase<Notification, int, TDbContext>, INotificationRepository where TDbContext : DbContext {
    public NotificationRepository(TDbContext dbContext) : base(dbContext) {
    }
}
