using Microsoft.Extensions.Options;
using NotificationService.Domain.IRetryQueue;
using NotificationService.Domain.Managers.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Configurations.Channels;

namespace NotificationService.Infrastructure.NotificationChannels;

public class PushNotificationChannel : NotificationChannel
{
    public PushNotificationChannel(
        INotificationProviderManager providerManager,
        IOptions<PushNotificationChannelConfiguration> configuration, INotificationRetryQueue retryQueue)
        : base(providerManager, configuration, retryQueue)
    {
    }
}