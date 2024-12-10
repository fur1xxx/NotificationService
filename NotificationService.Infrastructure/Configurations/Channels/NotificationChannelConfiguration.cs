﻿using NotificationService.Domain.Enums;

namespace NotificationService.Infrastructure.Configurations;

// Properties which all channels will have
public class NotificationChannelConfiguration
{
    public NotificationChannelType ChannelType { get; set; }
    public bool IsEnabled { get; set; }
}