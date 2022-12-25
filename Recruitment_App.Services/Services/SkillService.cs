using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;

namespace Recruitment_App.Services.Services
{
    public class SkillService : IService<Skill, int>
    {
        private readonly IRepository<Skill, int> _skillsRepo;
        public SkillService(IRepository<Skill, int> SkillsRepo)
        {
            _skillsRepo = SkillsRepo;
        }

        public Task<Skill> Add(Skill payload)
        {
            return _skillsRepo.AddAsync(payload);
        }

        public async Task<EntityState> Delete(int id)
        {
            var entity = await _skillsRepo.GetByIdAsync(id);
            if (entity == null) return EntityState.Detached;
            await _skillsRepo.DeleteAsync(entity);
            return EntityState.Deleted;
        }

        public async Task<EntityState> Edit(int id, Skill payload)
        {
            var entity = await _skillsRepo.GetByIdAsync(id);
            if (entity == null) return EntityState.Detached;
            await _skillsRepo.UpdateAsync(entity);
            return EntityState.Modified;
        }

        public async Task<IEnumerable<Skill>> GetAll()
        {
            return await _skillsRepo.GetAllAsync();
        }

        public Task<Skill> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
