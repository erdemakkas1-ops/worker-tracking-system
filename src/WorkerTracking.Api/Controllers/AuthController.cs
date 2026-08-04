using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WorkerTracking.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("login")]
    public IActionResult Login() 
    {
        return Ok("Login endpoint is  ready");
    }
}