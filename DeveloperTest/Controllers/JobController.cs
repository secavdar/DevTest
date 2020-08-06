using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DeveloperTest.Controllers
{
    [ApiController, Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly IJobService _jobService;

        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var jobs = await _jobService.GetJobsAsync();
            return Ok(jobs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var job = await _jobService.GetJobAsync(id);

            if (job == null)
            {
                return NotFound();
            }

            return Ok(job);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BaseJobModel model)
        {
            if (model.When.Date < DateTime.Now.Date)
            {
                return BadRequest("Date cannot be in the past");
            }

            var job = await _jobService.CreateJobAsync(model);

            return Created($"job/{job.JobId}", job);
        }
    }
}