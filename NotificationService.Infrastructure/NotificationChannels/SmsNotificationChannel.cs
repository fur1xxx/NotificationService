using Microsoft.Extensions.Options;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.NotificationChannels;

public class SmsNotificationChannel : NotificationChannel
{
    public SmsNotificationChannel(
        INotificationProviderManager providerManager,
        IOptions<SmsNotificationChannelConfiguration> configuration)
        : base(providerManager, configuration)
    {
    }
}