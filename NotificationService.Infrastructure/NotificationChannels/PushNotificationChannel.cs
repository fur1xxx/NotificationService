using Microsoft.Extensions.Options;
using NotificationService.Domain.IManagers;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.NotificationChannels;

public class PushNotificationChannel : NotificationChannel
{
    public PushNotificationChannel(
        INotificationProviderManager providerManager,
        IOptions<PushNotificationChannelConfiguration> configuration)
        : base(providerManager, configuration)
    {
    }
}