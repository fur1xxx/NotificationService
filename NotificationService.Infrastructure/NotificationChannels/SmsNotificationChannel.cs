using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;

namespace NotificationService.Infrastructure.NotificationChannels;

public class SmsNotificationChannel : NotificationChannel
{
    public SmsNotificationChannel(INotificationProviderManager providerManager)
        : base(providerManager) { }

    public override NotificationChannelType ChannelType => NotificationChannelType.SMS;
}