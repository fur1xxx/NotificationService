using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;

namespace NotificationService.Infrastructure.NotificationChannels;

public class PushNotificationChannel : NotificationChannel
{
    public PushNotificationChannel(INotificationProviderManager providerManager)
        : base(providerManager) { }

    public override NotificationChannelType ChannelType => NotificationChannelType.Push;
}