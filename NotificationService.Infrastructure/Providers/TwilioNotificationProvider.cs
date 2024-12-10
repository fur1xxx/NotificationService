using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Infrastructure.Providers;

public class TwilioNotificationProvider : INotificationProvider
{
    private readonly List<NotificationChannelType> _supportedChannels;

    public TwilioNotificationProvider()
    {
        _supportedChannels = new List<NotificationChannelType>
        {
            NotificationChannelType.Email,
            NotificationChannelType.SMS,
            NotificationChannelType.Push
        };
    }
    
    public bool SupportsChannel(NotificationChannelType channelType)
    {
         return _supportedChannels.Contains(channelType);
    }

    public async Task<bool> SendAsync(Notification notification)
    {
        if (!SupportsChannel(notification.ChannelType))
        {
            throw new NotSupportedException($"Channel {notification.ChannelType} is not supported by Twilio");
        }
        
        Console.WriteLine($"Sending {notification.ChannelType} via Twilio to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100);
        return true;
    }
}