using MediatR;
using WorkerTracking.Application.Features.Auth.Login;

namespace WorkerTracking.Application.Features.Auth.Me;

public sealed record GetCurrentUserQuery : IRequest<UserDto>;