﻿using Microsoft.Extensions.Options;
using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Enums;
using NotificationService.Domain.IManagers;
using NotificationService.Infrastructure.Configurations;

namespace NotificationService.Infrastructure.NotificationChannels;

public abstract class NotificationChannel : INotificationChannel
{
    private readonly INotificationProviderManager _providerManager;
    protected readonly NotificationChannelConfiguration _configuration;

    protected NotificationChannel(INotificationProviderManager providerManager, IOptions<NotificationChannelConfiguration> configuration)
    {
        _providerManager = providerManager;
        _configuration = configuration.Value;
    }

    public NotificationChannelType ChannelType => _configuration.ChannelType;

    public bool IsEnabled => _configuration.IsEnabled;

    public async Task<bool> SendNotificationAsync(Notification notification)
    {
        IEnumerable<INotificationProvider> providers = _providerManager.GetProvidersForChannel(notification.ChannelType);

        foreach (INotificationProvider provider in providers)
        {
            try
            {
                if (await provider.SendAsync(notification))
                {
                    Console.WriteLine($"Notification sent via {provider.GetType().Name}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send notification via {provider.GetType().Name}: {ex.Message}");
            }
        }

        Console.WriteLine($"All providers for {ChannelType} failed. Notification will be queued for retry.");
        return false;
    }
}