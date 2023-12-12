using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UseNotify.Entities;

namespace UseNotify.Configurations;

public class NotificationConfiguration : IEntityTypeConfiguration<Notification> {
    public void Configure(EntityTypeBuilder<Notification> builder) {
        builder.ToTable("Notifications").HasKey(n => n.NotificationId);
        builder.Property(n => n.NotificationId);
        builder.Property(n => n.RecepeintId).IsRequired();
        builder.Property(n => n.Title).IsRequired();
        builder.Property(n => n.Content).IsRequired();
    }
}
