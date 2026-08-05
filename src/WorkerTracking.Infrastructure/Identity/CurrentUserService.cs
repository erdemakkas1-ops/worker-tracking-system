using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Infrastructure.Identity;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            var userId = _httpContextAccessor.HttpContext?
                .User?
                .FindFirstValue(ClaimTypes.NameIdentifier);

            if (Guid.TryParse(userId, out var id))
            {
                return id;
            }

            return null;
        }
    }
}