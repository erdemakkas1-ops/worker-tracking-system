namespace WorkerTracking.Application.Features.Auth.Login;

public sealed class LoginResponseDto
{
    public string Token { get; set; } = string.Empty;

    public DateTime ExpiresAtUtc { get; set; }

    public UserDto User { get; set; } = new();
}