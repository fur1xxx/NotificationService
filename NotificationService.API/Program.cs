using NotificationService.Domain.Contracts.INotificationChannels;
using NotificationService.Domain.Contracts.IProviders;
using NotificationService.Domain.IManagers;
using NotificationService.Domain.Services.Interfaces;
using NotificationService.Infrastructure.Configurations;
using NotificationService.Infrastructure.Extensions;
using NotificationService.Infrastructure.Managers;
using NotificationService.Infrastructure.NotificationChannels;
using NotificationService.Infrastructure.Providers;

namespace NotificationService.API;

public class Program
{
    public static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);


        builder.Services.AddNotificationServices(builder.Configuration);
        
        builder.Services.AddControllers();
        
        builder.Services.AddAuthorization();
        
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        WebApplication app = builder.Build();
        
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();
        
        app.MapControllers();

        app.Run();
    }
}