using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Entities;
using NotificationService.Domain.IManagers;
using NotificationService.Domain.Services.Interfaces;

namespace NotificationService.Infrastructure.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationChannelManager _notificationChannelManager;
    
    public NotificationService(INotificationChannelManager notificationChannelManager)
    {
        _notificationChannelManager = notificationChannelManager;
    }
    
    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        try
        {
            INotificationChannel notificationChannel = _notificationChannelManager.GetNotificationChannel(notification.ChannelType);
            
            if(await notificationChannel.SendNotificationAsync(notification))
            {
                Console.WriteLine($"Notification sent via {notificationChannel.GetType().Name}");
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error sending notification: {ex.Message}");
        }
        
        Console.WriteLine("Notification failed to send");
        return false;
    }
}