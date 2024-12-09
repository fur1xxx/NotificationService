using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IProvider;

namespace NotificationService.Infrastructure.Providers;

public class VonageNotificationProvider : INotificationProvider
{
    private readonly List<NotificationChannel> _supportedChannels = new()
    {
        NotificationChannel.Email,
        NotificationChannel.SMS,
        NotificationChannel.Push
    };
    
    public bool SupportsChannel(NotificationChannel channel)
    {
        return _supportedChannels.Contains(channel);
    }

    public async Task<bool> SendAsync(Notification notification)
    {
        if (!SupportsChannel(notification.Channel))
        {
            throw new NotSupportedException($"Channel {notification.Channel} is not supported by Vonage.");
        }

        Console.WriteLine($"Sending {notification.Channel} via Vonage to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100); 
        return true;
    }
}