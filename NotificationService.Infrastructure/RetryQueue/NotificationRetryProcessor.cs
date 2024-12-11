using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NotificationService.Domain.Entities;
using NotificationService.Domain.IRetryQueue;
using NotificationService.Domain.Services.Interfaces;

namespace NotificationService.Infrastructure.RetryQueue;

public class NotificationRetryProcessor : BackgroundService
{
    private INotificationRetryQueue _retryQueue;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public NotificationRetryProcessor(IServiceScopeFactory serviceScopeFactory, INotificationRetryQueue retryQueue)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _retryQueue = retryQueue;
    }
    
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_retryQueue.TryDequeue(out Notification notification))
            {
                try
                {
                    using (IServiceScope scope = _serviceScopeFactory.CreateScope())
                    {
                        Console.WriteLine($"Retrying notification {notification.Id}");
                        INotificationService notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();
                        await notificationService.SendNotificationAsync(notification);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Retry failed for notification {notification.Id}: {ex.Message}");
                }
            }
            await Task.Delay(5000, stoppingToken);
        }
    }
}