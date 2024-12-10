using Microsoft.Extensions.Options;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.Providers;

public class TwilioNotificationProvider : INotificationProvider
{
    private readonly TwilioProviderConfiguration _configuration;

    public TwilioNotificationProvider(IOptions<TwilioProviderConfiguration> configuration)
    {
        _configuration = configuration.Value;
    }
    
    public int Priority => _configuration.Priority;
    
    public bool SupportsChannel(NotificationChannelType channelType)
    {
        return _configuration.SupportedChannels.Contains(channelType);
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