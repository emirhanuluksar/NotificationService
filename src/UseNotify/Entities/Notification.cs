using UseNotify.Repositories;

namespace UseNotify.Entities;

public class Notification : Entity<int> {
    public int RecepeintId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
