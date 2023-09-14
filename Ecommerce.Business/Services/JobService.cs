using AutoMapper;
using Ecommerce.Common.Dtos.Jobs;
using Ecommerce.Common.Interfaces;
using Ecommerce.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Business.Services
{
    public class JobService : IJobService
    {
        public IMapper Mapper { get; }
        public IGenericRepository<Job> Job { get; }

        public JobService(IMapper mapper, IGenericRepository<Job> JobRepository)
        {
            Mapper = mapper;
            Job = JobRepository;
        }
        public async Task<int> CraeteJobAsync(JobCreate jobCreate)
        {
            var entity = Mapper.Map<Job>(jobCreate);
            await Job.InsertAsync(entity);
            await Job.SaveChangesAsync();
            return entity.Id;
        }

        public async Task DeleteJobAsync(JobDelete jobDelete)
        {
            var entity = await Job.GetByIdAsync(jobDelete.id);
            Job.Delete(entity);
            await Job.SaveChangesAsync();
        }

        public async Task<JobGet> GetJobAsync(int id)
        {
            var entity = await Job.GetByIdAsync(id);
            return Mapper.Map<JobGet>(entity);

        }

        public async Task<List<JobGet>> GetJobsAsync()
        {
            var entity = await Job.GetAysnc(null, null);
            return Mapper.Map<List<JobGet>>(entity);

        }

        public async Task UpdateJobAsync(JobUpdate jobUpdate)
        {
            var entity = Mapper.Map<Job>(jobUpdate);
            Job.Update(entity);
            await Job.SaveChangesAsync();

        }
    }

}
