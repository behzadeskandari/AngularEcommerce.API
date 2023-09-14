using Ecommerce.Common.Dtos.Jobs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Common.Interfaces
{
    public interface IJobService
    {
        Task<int> CraeteJobAsync(JobCreate jobCreate);

        Task UpdateJobAsync(JobUpdate jobUpdate);

        Task<List<JobGet>> GetJobsAsync();

        Task<JobGet> GetJobAsync(int id);

        Task DeleteJobAsync(JobDelete jobDelete);

    }
}
