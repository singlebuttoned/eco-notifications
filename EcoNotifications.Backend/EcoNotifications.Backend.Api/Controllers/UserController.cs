using System.Collections;
using Microsoft.AspNetCore.Mvc;

namespace EcoNotifications.Backend.Api.Controllers;

[Produces("application/json")]
[ApiController]
[Route("api/admin/[controller]")]
public class UserController : ControllerBase
{
    // private readonly ;

    public UserController()
    {

    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable> Get()
    {
        return Enumerable.Range(1, 5).ToArray();
    }
}