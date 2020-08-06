using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext _context;

        public JobService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<JobModel[]> GetJobsAsync()
        {
            return await _context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                Customer = !x.CustomerId.HasValue ? null : new CustomerModel
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    Type = x.Customer.Type
                },
                When = x.When
            }).ToArrayAsync();
        }

        public async Task<JobModel> GetJobAsync(int jobId)
        {
            return await _context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                Customer = !x.CustomerId.HasValue ? null : new CustomerModel
                {
                    Id = x.Customer.Id,
                    Name = x.Customer.Name,
                    Type = x.Customer.Type
                },
                When = x.When
            }).SingleOrDefaultAsync();
        }

        public async Task<JobModel> CreateJobAsync(BaseJobModel model)
        {
            var addedJob = await _context.Jobs.AddAsync(new Job
            {
                Engineer = model.Engineer,
                CustomerId = model.Customer.Id,
                When = model.When
            });

            await _context.SaveChangesAsync();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                Customer = model.Customer,
                When = addedJob.Entity.When
            };
        }
    }
}
