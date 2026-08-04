namespace WorkerTracking.Application.Features.Auth.Login;

public sealed record class UserDto
{
    public Guid Id { get; set;}

    public string Email { get; set;} = string.Empty;

    public string FirstName { get; set;} = string.Empty;

    public string LastName { get; set;} = string.Empty;

    public string Role { get; set;} = string.Empty;
}