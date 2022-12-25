using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;

namespace Recruitment_App.Services.Services
{
    public class JobCategoryService : IService<JobCategory, int>
    {
        private readonly IRepository<JobCategory, int> _jobCategoryRepo;
        public JobCategoryService(IRepository<JobCategory, int> jobCategoryRepo)
        {
            _jobCategoryRepo = jobCategoryRepo;
        }

        public Task<JobCategory> Add(JobCategory payload)
        {
            return _jobCategoryRepo.AddAsync(payload);
        }

        public async Task<EntityState> Delete(int id)
        {
            var entity = await _jobCategoryRepo.GetByIdAsync(id);
            if (entity == null) return EntityState.Detached;
            await _jobCategoryRepo.DeleteAsync(entity);
            return EntityState.Deleted;
        }

        public async Task<EntityState> Edit(int id, JobCategory payload)
        {
            var entity = await _jobCategoryRepo.GetByIdAsync(id);
            if (entity == null) return EntityState.Detached;
            await _jobCategoryRepo.UpdateAsync(entity);
            return EntityState.Modified;
        }

        public async Task<IEnumerable<JobCategory>> GetAll()
        {
            return await _jobCategoryRepo.GetAllAsync();
        }

        public Task<JobCategory> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
