using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;

namespace Recruitment_App.Services.Services
{
    public class ApplicantService : IService<Applicant, Guid>
    {
        private readonly IRepository<Applicant, Guid> _applicantsRepo;
        public ApplicantService(IRepository<Applicant, Guid> applicantsRepo)
        {
            _applicantsRepo = applicantsRepo;
        }

        public Task<Applicant> Add(Applicant payload)
        {
            return _applicantsRepo.AddAsync(payload);
        }

        public async Task<EntityState> Delete(Guid id)
        {
            var entity = await _applicantsRepo.GetByIdAsync(id);
            if(entity == null) return EntityState.Detached;
            await _applicantsRepo.DeleteAsync(entity);
            return EntityState.Deleted;
        }

        public async Task<EntityState> Edit(Guid id, Applicant payload)
        {
            var entity = await _applicantsRepo.GetByIdAsync(id);
            if(entity==null) return EntityState.Detached;
            await _applicantsRepo.UpdateAsync(entity);
            return EntityState.Modified;
        }

        public async Task<IEnumerable<Applicant>> GetAll()
        {
            return await _applicantsRepo.GetAllAsync();
        }

        public Task<Applicant> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
