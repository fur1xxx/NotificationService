using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;

namespace NotificationService.Infrastructure.Providers;

public class VonageNotificationProvider : INotificationProvider
{
    private readonly List<NotificationChannelType> _supportedChannels = new()
    {
        NotificationChannelType.Email,
        NotificationChannelType.SMS,
        NotificationChannelType.Push
    };
    
    public bool SupportsChannel(NotificationChannelType channelType)
    {
        return _supportedChannels.Contains(channelType);
    }

    public async Task<bool> SendAsync(Notification notification)
    {
        if (!SupportsChannel(notification.ChannelType))
        {
            throw new NotSupportedException($"Channel {notification.ChannelType} is not supported by Vonage.");
        }

        Console.WriteLine($"Sending {notification.ChannelType} via Vonage to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100); 
        return true;
    }
}