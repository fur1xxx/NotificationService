using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Entities;

public class Notification
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Recipient { get; set; }
    public string Message { get; set; }
    public NotificationChannelType ChannelType { get; set; }
    public DateTime CreatedAt { get; set; }
}