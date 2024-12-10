using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.Enums;

namespace NotificationService.Domain.IManagers;

public interface INotificationProviderManager
{
    IEnumerable<INotificationProvider> GetProvidersForChannel(NotificationChannelType channelType);
}