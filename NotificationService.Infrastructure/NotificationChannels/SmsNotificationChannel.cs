using Microsoft.Extensions.Options;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IRetryQueue;
using NotificationService.Domain.Managers.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Configurations.Channels;

namespace NotificationService.Infrastructure.NotificationChannels;

public class SmsNotificationChannel : NotificationChannel
{
    public SmsNotificationChannel(
        INotificationProviderManager providerManager,
        IOptions<SmsNotificationChannelConfiguration> configuration,
        INotificationRetryQueue retryQueue)
        : base(providerManager, configuration, retryQueue)
    {
    }
}