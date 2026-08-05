using Microsoft.EntityFrameworkCore;
using MediatR;
using WorkerTracking.Application.Common.Interfaces;
using WorkerTracking.Application.Features.Auth.Login;

namespace WorkerTracking.Application.Features.Auth.Me;

public sealed class GetCurrentUserQueryHandler
    : IRequestHandler<GetCurrentUserQuery, UserDto>
{
    private readonly IApplicationDbContext _context;
    private readonly ICurrentUserService _currentUserService;

    public GetCurrentUserQueryHandler(
        IApplicationDbContext context,
        ICurrentUserService currentUserService)
    {
        _context = context;
        _currentUserService = currentUserService;
    }

    public async Task<UserDto> Handle(
        GetCurrentUserQuery request,
        CancellationToken cancellationToken)
    {
        if (_currentUserService.UserId is null)
        {
            throw new UnauthorizedAccessException("User is not authenticated.");
        }

        var user = await _context.Users
            .FirstOrDefaultAsync(
                x => x.Id == _currentUserService.UserId,
                cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedAccessException("User not found.");
        }

        return new UserDto
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Role = string.Empty
        };
    }
}