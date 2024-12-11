using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.IRetryQueue;
using NotificationService.Domain.Managers;
using NotificationService.Domain.Managers.Interfaces;
using NotificationService.Domain.Services.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Configurations.Channels;
using NotificationService.Infrastructure.Configurations.Providers;
using NotificationService.Infrastructure.NotificationChannels;
using NotificationService.Infrastructure.Providers;
using NotificationService.Infrastructure.RetryQueue;

namespace NotificationService.Infrastructure.Extensions;

public static class NotificationServiceExtensions
{
    public static IServiceCollection AddNotificationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<INotificationService, Services.NotificationService>();
            
            services.AddScoped<INotificationProvider, TwilioNotificationProvider>();
            services.AddScoped<INotificationProvider, AmazonSnsNotificationProvider>();
            services.AddScoped<INotificationProvider, VonageNotificationProvider>();
            
            services.AddScoped<INotificationProviderManager, NotificationProviderManager>();
            services.AddScoped<INotificationChannelManager, NotificationChannelManager>();
            
            services.AddScoped<INotificationChannel, EmailNotificationChannel>();
            services.AddScoped<INotificationChannel, SmsNotificationChannel>();
            services.AddScoped<INotificationChannel, PushNotificationChannel>();

            services.AddSingleton<INotificationRetryQueue, NotificationRetryQueue>();

            services.AddHostedService<NotificationRetryProcessor>();
            
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