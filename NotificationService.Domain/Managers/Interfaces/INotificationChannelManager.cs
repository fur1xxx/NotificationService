using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.Managers.Interfaces;

public interface INotificationChannelManager
{
    INotificationChannel GetNotificationChannel(NotificationChannelType channelType);
}