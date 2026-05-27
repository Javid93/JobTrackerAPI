using JobTrackerAPI.Data;
using JobTrackerAPI.DTOs;
using JobTrackerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobTrackerAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class JobApplicationsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public JobApplicationsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobApplication>>> GetAll()
    {
        var applications = await _context.JobApplications.ToListAsync();
        return Ok(applications);
    }


    [HttpPost]
    public async Task<ActionResult<JobApplication>> Create(JobApplicationCreateDTO dto)
    {
        var exists = await _context.JobApplications.AnyAsync(j =>
            j.CompanyName.ToLower() == dto.CompanyName.ToLower() &&
            j.PositionTitle.ToLower() == dto.PositionTitle.ToLower()

        );

        if (exists)
        {
            return Conflict(new
            {
                message = "A job application for this company and position already exists."
            });
        }

        var jobApplication = new JobApplication
        {
            CompanyName = dto.CompanyName,
            PositionTitle = dto.PositionTitle,
            Status = dto.Status,
            AppliedDate = dto.AppliedDate,
            JobUrl = dto.JobUrl,
            Notes = dto.Notes
        };

        _context.JobApplications.Add(jobApplication);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = jobApplication.ID }, jobApplication);


    }
}