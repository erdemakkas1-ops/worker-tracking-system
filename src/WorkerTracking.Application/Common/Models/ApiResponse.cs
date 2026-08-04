namespace WorkerTracking.Application.Common.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T? Data { get; set; }
    public IReadOnlyList<string>? Errors { get; set; }

    public static ApiResponse<T> Ok(T data) => new() { Success = true, Data = data };

    public static ApiResponse<T> Fail(params string[] errors) => new()
    {
        Success = false,
        Errors = errors
    };
}
