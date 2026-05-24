namespace JobTrackerAPI.Models;

public class JobApplication
{
    public int ID { get; set; }

    public string CompanyName { get; set; } = string.Empty;

    public string PositionTitle { get; set; } = string.Empty;

    public string Status { get; set; } = "Applied";

    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

    public string? Notes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}