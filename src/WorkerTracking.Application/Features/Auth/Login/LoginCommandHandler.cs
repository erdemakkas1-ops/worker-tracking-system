using MediatR;

namespace WorkerTracking.Application.Features.Auth.Login;

public sealed class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResponseDto>
{
    public Task<LoginResponseDto> Handle( LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}