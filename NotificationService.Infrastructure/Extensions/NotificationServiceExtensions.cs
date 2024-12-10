using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.IManagers;
using NotificationService.Domain.Services.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Managers;
using NotificationService.Infrastructure.NotificationChannels;
using NotificationService.Infrastructure.Providers;

namespace NotificationService.Infrastructure.Extensions;

public static class NotificationServiceExtensions
{
    public static IServiceCollection AddNotificationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationService, Services.NotificationService>();
            
            services.AddScoped<INotificationProvider, TwilioNotificationProvider>();
            services.AddScoped<INotificationProvider, AmazonSnsNotificationProvider>();
            services.AddScoped<INotificationProvider, VonageNotificationProvider>();
            
            services.AddScoped<INotificationChannel, EmailNotificationChannel>();
            services.AddScoped<INotificationChannel, SmsNotificationChannel>();
            services.AddScoped<INotificationChannel, PushNotificationChannel>();
            
            services.AddScoped<INotificationProviderManager, NotificationProviderManager>();
            services.AddScoped<INotificationChannelManager, NotificationChannelManager>();
            
            services.Configure<EmailNotificationChannelConfiguration>(
                configuration.GetSection("NotificationSettings:Channels:EmailChannel"));
            services.Configure<SmsNotificationChannelConfiguration>(
                configuration.GetSection("NotificationSettings:Channels:SmsChannel"));
            services.Configure<PushNotificationChannelConfiguration>(
                configuration.GetSection("NotificationSettings:Channels:PushChannel"));
            
            services.Configure<AmazonSnsProviderConfiguration>(
                configuration.GetSection("NotificationSettings:Providers:AmazonSns"));
            services.Configure<TwilioProviderConfiguration>(
                configuration.GetSection("NotificationSettings:Providers:Twilio"));
            services.Configure<VonageProviderConfiguration>(
                configuration.GetSection("NotificationSettings:Providers:Vonage"));

            return services;
        }
}