using Microsoft.Extensions.Options;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.NotificationChannels;

public class EmailNotificationChannel : NotificationChannel
{
    public EmailNotificationChannel(
        INotificationProviderManager providerManager,
        IOptions<EmailNotificationChannelConfiguration> configuration)
        : base(providerManager, configuration)
    {
    }
}