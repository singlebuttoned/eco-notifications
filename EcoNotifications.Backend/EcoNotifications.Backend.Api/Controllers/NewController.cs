using Microsoft.AspNetCore.Mvc;

namespace EcoNotifications.Backend.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class NewController : ControllerBase
{
    private readonly ILogger<NewController> _logger;

    public NewController(ILogger<NewController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "Get")]
    public async Task<int[]> Get()
    {
        return Enumerable.Range(1, 5).ToArray();
    }
}