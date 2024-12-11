using Microsoft.Extensions.Options;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Configurations.Providers;

namespace NotificationService.Infrastructure.Providers;

public class AmazonSnsNotificationProvider : INotificationProvider
{
    private readonly AmazonSnsProviderConfiguration _configuration;

    public AmazonSnsNotificationProvider(IOptions<AmazonSnsProviderConfiguration> configuration)
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
            throw new NotSupportedException($"Channel {notification.ChannelType} is not supported by Amazon SNS.");
        }
        
        Console.WriteLine($"Sending {notification.ChannelType} via Amazon SNS to {notification.Recipient}: {notification.Message}");
        await Task.Delay(100); 
        return true; 
    }
}