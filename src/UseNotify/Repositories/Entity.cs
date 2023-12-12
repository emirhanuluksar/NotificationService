
namespace UseNotify.Repositories;

public class Entity<TId> : IEntityTimestamps {
    public TId Id { get; set; } = default!;
    public DateTime CreatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}
