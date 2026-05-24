using System.ComponentModel.DataAnnotations;

namespace JobTrackerAPI.DTOs;

public class JobApplicationCreateDTO
{
    [Required]
    [MaxLength(100)]
    public string CompanyName { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string PositionTitle { get; set; } = string.Empty;

    [Required]
    public string Status { get; set; } = "Applied";

    public DateTime AppliedDate { get; set; } = DateTime.UtcNow;

    [MaxLength(500)]
    public string? Notes { get; set; }
}
