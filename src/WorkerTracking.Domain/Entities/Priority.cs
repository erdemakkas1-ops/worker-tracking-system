namespace WorkerTracking.Domain.Entities;

public class Priority
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int SortOrder { get; set; }
    public string ColorHex { get; set; } = string.Empty;
}
