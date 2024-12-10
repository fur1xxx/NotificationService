using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.IManagers;

public interface INotificationChannelManager
{
    INotificationChannel GetNotificationChannel(NotificationChannelType channelType);
}