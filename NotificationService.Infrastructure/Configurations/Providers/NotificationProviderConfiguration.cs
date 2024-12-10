using NotificationService.Domain.Enums;

namespace NotificationService.Infrastructure.Configurations;

public class NotificationProviderConfiguration
{
    public string ProviderName { get; set; }
    public int Priority { get; set; }
    public IEnumerable<NotificationChannelType> SupportedChannels { get; set; }
}