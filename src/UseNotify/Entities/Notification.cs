namespace UseNotify.Entities;

public class Notification {
    public int NotificationId { get; set; }
    public int RecepeintId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
}
