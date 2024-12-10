using Microsoft.Extensions.Options;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.Providers;

public class VonageNotificationProvider : INotificationProvider
{
    private readonly VonageProviderConfiguration _configuration;

    public VonageNotificationProvider(IOptions<VonageProviderConfiguration> configuration)
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
            throw new NotSupportedException($"Channel {notification.ChannelType} is not supported by Vonage.");
        }

        Console.WriteLine($"Sending {notification.ChannelType} via Vonage to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100); 
        return true;
    }
}