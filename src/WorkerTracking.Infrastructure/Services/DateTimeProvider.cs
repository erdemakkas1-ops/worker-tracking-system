using WorkerTracking.Application.Common.Interfaces;

namespace WorkerTracking.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
