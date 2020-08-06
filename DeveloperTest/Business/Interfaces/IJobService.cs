using DeveloperTest.Models;
using System.Threading.Tasks;

namespace DeveloperTest.Business.Interfaces
{
    public interface IJobService
    {
        Task<JobModel[]> GetJobsAsync();

        Task<JobModel> GetJobAsync(int jobId);

        Task<JobModel> CreateJobAsync(BaseJobModel model);
    }
}
