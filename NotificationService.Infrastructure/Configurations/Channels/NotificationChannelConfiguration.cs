using NotificationService.Domain.Enums;

namespace NotificationService.Infrastructure.Configurations;

public class NotificationChannelConfiguration
{
    public NotificationChannelType ChannelType { get; set; }
    public bool IsEnabled { get; set; }
}