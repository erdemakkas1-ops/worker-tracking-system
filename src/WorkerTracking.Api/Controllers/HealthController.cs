using Microsoft.AspNetCore.Mvc;
using WorkerTracking.Application.Common.Models;

namespace WorkerTracking.Api.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<ApiResponse<object>> Get()
    {
        return Ok(ApiResponse<object>.Ok(new
        {
            status = "healthy",
            timestamp = DateTime.UtcNow
        }));
    }
}
