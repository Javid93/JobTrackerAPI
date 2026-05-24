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
        var jobApplication = new JobApplication
        {
            CompanyName = dto.CompanyName,
            PositionTitle = dto.PositionTitle,
            Status = dto.Status,
            AppliedDate = dto.AppliedDate,
            Notes = dto.Notes
        };

        _context.JobApplications.Add(jobApplication);

        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = jobApplication.ID }, jobApplication);


    }
}