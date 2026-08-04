using MediatR;

namespace WorkerTracking.Application.Features.Auth.Login;

public sealed record LoginCommand(string Email, string Password) : IRequest<LoginResponseDto>;