using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UseNotify.Hubs;
using UseNotify.Repositories;
using UseNotify.Services;

namespace UseNotify.Extensions;

public static class UseNotifyExtensions {
    public static IServiceCollection AddUseNotify<TDbContext>(this IServiceCollection services)
        where TDbContext : DbContext {
        services.AddSignalR();
        services.AddSingleton<NotificationHub>();
        services.AddScoped<INotificationRepository>(provider => {
            var dbContext = provider.GetRequiredService<TDbContext>();
            return new NotificationRepository<TDbContext>(dbContext);
        });
        services.AddScoped<INotificationService, NotificationManager>();

        return services;
    }
}
