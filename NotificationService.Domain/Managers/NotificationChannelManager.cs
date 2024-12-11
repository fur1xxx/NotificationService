using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Enums;
using NotificationService.Domain.Managers.Interfaces;

namespace NotificationService.Domain.Managers;

public class NotificationChannelManager : INotificationChannelManager
{
    private readonly IEnumerable<INotificationChannel> _notificationChannels;
    
    public NotificationChannelManager(IEnumerable<INotificationChannel> notificationChannels)
    {
        _notificationChannels = notificationChannels;
    }
    
    public INotificationChannel GetNotificationChannel(NotificationChannelType channelType)
    {
        INotificationChannel? channel = _notificationChannels.FirstOrDefault(c => c.ChannelType == channelType);
        
        if (channel == null)
        {
            throw new InvalidOperationException($"No notification channel found for type {channelType}");
        }
        
        if (!channel.IsEnabled)
        {
            throw new InvalidOperationException($"Notification channel {channelType} is disabled");
        }

        return channel;
    }
}