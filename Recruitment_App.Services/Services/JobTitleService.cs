using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Services.IServices;
using System.Linq.Expressions;
using Ganss.Xss;

namespace Recruitment_App.Services.Services
{
    public class JobTitleService : IJobTitleService<JobTitle, Guid>
    {
        private readonly IRepository<JobTitle, Guid> _jobTitlesRepo;
        private readonly IRepository<JobTitleSkill, Guid> _jobTitleSkillsRepo;
        private readonly HtmlSanitizer _htmlSanitizer;
        public JobTitleService(IRepository<JobTitle, Guid> jobTitlesRepo, IRepository<JobTitleSkill, Guid> jobTitleSkillsRepo = null)
        {
            _jobTitlesRepo = jobTitlesRepo;
            _htmlSanitizer = new HtmlSanitizer();
            _jobTitleSkillsRepo = jobTitleSkillsRepo;
        }

        public Task<JobTitle> Add(JobTitle payload)
        {
            payload.Id = Guid.NewGuid();
            payload.Skills = new List<JobTitleSkill>();
            payload.Responsibilities = _htmlSanitizer.Sanitize(payload.Responsibilities);
            payload.Description = _htmlSanitizer.Sanitize(payload.Description);
            foreach (var item in payload.SelectedSkillsIds)
            {
                payload.Skills.Add(new JobTitleSkill
                {
                    Id = Guid.NewGuid(),
                    JobTitleId = payload.Id,
                    SkillId = item,
                    Skills = null,
                    JobTitles = null
                });
            }
            return _jobTitlesRepo.AddAsync(payload);
        }

        public async Task<EntityState> Delete(Guid id)
        {
            var entity = await _jobTitlesRepo.GetByIdAsync(id);
            if (entity == null) return EntityState.Detached;
            entity.IsDeleted = true;
            await _jobTitlesRepo.UpdateAsync(entity);
            return EntityState.Deleted;
        }

        public async Task<EntityState> Edit(Guid id, JobTitle payload)
        {
            //var entity = await _jobTitlesRepo.GetByIdAsync(id);
            //if (entity == null) return EntityState.Detached;
            await _jobTitleSkillsRepo.DeleteBulkAsync(x => x.JobTitleId == payload.Id);
            foreach (var item in payload.SelectedSkillsIds)
            {
                payload.Skills.Add(new JobTitleSkill
                {
                    Id = Guid.NewGuid(),
                    JobTitleId = payload.Id,
                    SkillId = item,
                    Skills = null,
                    JobTitles = null
                });
            }
            await _jobTitlesRepo.UpdateAsync(payload);
            await _jobTitleSkillsRepo.AddBulkAsync(payload.Skills.ToList());
            return EntityState.Modified;
        }

        public async Task<IEnumerable<JobTitle>> GetAll()
        {
       
            return await _jobTitlesRepo.GetAsync(predicates: new List<Expression<Func<JobTitle, bool>>> { j => !j.IsDeleted }, null,
                includes: new List<Expression<Func<JobTitle, object>>> { j => j.Skills, j => j.JobCategory }, true);
        }

        public async Task<IEnumerable<JobTitle>> GetAllAvailable()
        {
            return await _jobTitlesRepo.GetAsync(
                new List<Expression<Func<JobTitle, bool>>> { j => !j.IsDeleted, j => j.MaximumApplications > j.Applications.Count, j => j.ValidityDurationTo >= DateTime.Now }, null,
                includes: new List<Expression<Func<JobTitle, object>>> { j => j.Skills, j => j.JobCategory, j => j.Applications }, true);
        }

        public async Task<JobTitle> GetById(Guid id)
        {
            var entity = await _jobTitlesRepo.GetByIdAsync(x => x.Id == id, x => x.Skills, x => x.JobCategory);
            entity.SelectedSkillsIds = entity.Skills.Select(x => x.SkillId).ToList();
            return entity;
        }
    }
}
