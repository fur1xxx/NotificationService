using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IProvider;

namespace NotificationService.Infrastructure.Providers;

public class TwilioNotificationProvider : INotificationProvider
{
    private readonly List<NotificationChannel> _supportedChannels;

    public TwilioNotificationProvider()
    {
        _supportedChannels = new List<NotificationChannel>
        {
            NotificationChannel.Email,
            NotificationChannel.SMS,
            NotificationChannel.Push
        };
    }
    
    public bool SupportsChannel(NotificationChannel channel)
    {
         return _supportedChannels.Contains(channel);
    }

    public async Task<bool> SendAsync(Notification notification)
    {
        if (SupportsChannel(notification.Channel))
        {
            throw new NotSupportedException($"Channel {notification.Channel} is not supported by Twilio");
        }
        
        Console.WriteLine($"Sending {notification.Channel} via Twilio to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100);
        return true;
    }
}