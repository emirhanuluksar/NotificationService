namespace UseNotify.Repositories;

public interface IEntityTimestamps {
    DateTime CreatedAt { get; set; }
    DateTime? DeletedAt { get; set; }
}
