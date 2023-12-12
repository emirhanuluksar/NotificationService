using Microsoft.EntityFrameworkCore;
using UseNotify.Configurations;

namespace UseNotify.Extensions;

public static class ModelBuilderExtensions {

    public static void ApplyNotificationConfiguration(this ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
    }
}
