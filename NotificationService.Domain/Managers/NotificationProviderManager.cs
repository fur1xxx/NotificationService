﻿using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Enums;
using NotificationService.Domain.Managers.Interfaces;

namespace NotificationService.Domain.Managers;

public class NotificationProviderManager : INotificationProviderManager
{
    private readonly IEnumerable<INotificationProvider> _providers;

    public NotificationProviderManager(IEnumerable<INotificationProvider> providers)
    {
        _providers = providers;
    }

    public IEnumerable<INotificationProvider> GetProvidersForChannel(NotificationChannelType channelType)
    {
        return _providers
            .Where(p => p.SupportsChannel(channelType) && p.IsAvailable)
            .OrderBy(p => p.Priority);
    }
}