using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;

namespace NotificationService.Infrastructure.NotificationChannels;

public abstract class NotificationChannel : INotificationChannel
{
    private readonly INotificationProviderManager _providerManager;

    protected NotificationChannel(INotificationProviderManager providerManager)
    {
        _providerManager = providerManager;
    }

    public abstract NotificationChannelType ChannelType { get; }
    
    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        IEnumerable<INotificationProvider> providers = _providerManager.GetProvidersForChannel(notification.ChannelType);

        foreach (INotificationProvider provider in providers)
        {
            try
            {
                if (await provider.SendAsync(notification))
                {
                    Console.WriteLine($"Push notification sent via {provider.GetType().Name}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send SMS notification via {provider.GetType().Name}: {ex.Message}");
            }
        }

        Console.WriteLine("All SMS notification providers failed. SMS notification will be queued for retry.");
        return false;
    }
}