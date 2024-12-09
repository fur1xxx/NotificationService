using Microsoft.AspNetCore.Mvc;
using NotificationService.Domain.Entities;
using NotificationService.Domain.Services.Interfaces;

namespace NotificationService.API.Controllers;

[ApiController]
[Route("[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;
    
    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }
    
    [HttpPost]
    public async Task<IActionResult> SendNotification([FromBody] Notification notification)
    {
        bool result = await _notificationService.SendNotificationAsync(notification);
        
        if (result)
        {
            return Ok("Notification sent successfully.");
        }

        return StatusCode(500, "Failed to send notification.");
    }
}