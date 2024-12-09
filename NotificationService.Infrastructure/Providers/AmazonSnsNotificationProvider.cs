using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IProvider;

namespace NotificationService.Infrastructure.Providers;

public class AmazonSnsNotificationProvider : INotificationProvider
{
    private readonly List<NotificationChannel> _supportedChannels;
    
    public AmazonSnsNotificationProvider()
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
        if (!SupportsChannel(notification.Channel))
        {
            throw new NotSupportedException($"Channel {notification.Channel} is not supported by Amazon SNS.");
        }

        Console.WriteLine($"Sending {notification.Channel} via Amazon SNS to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100); 
        return true; 
    }
}