using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Recruitment_App.Services.Services
{
    public class ApplicationService : IApplicationService<Application, Guid>
    {
        private readonly IRepository<Application, Guid> _applicationsRepo;
        private readonly IRepository<Applicant, Guid> _applicantRepo;
        public ApplicationService(IRepository<Application, Guid> applicantsRepo, IRepository<Applicant, Guid> applicantRepo)
        {
            _applicationsRepo = applicantsRepo;
            _applicantRepo = applicantRepo;
        }

        public async Task<Application> Add(Application payload)
        {
            return await _applicationsRepo.AddAsync(payload);
        }

        public async Task Apply(Application payload)
        {
            var applicant = await checkIfUserAlreadyExists(payload.Applicants.Email);
            if (applicant == null)
                applicant = await _applicantRepo.AddAsync(payload.Applicants);

            var app = await checkIfApplicationAlreadyExists(applicant.Id, payload.JobTitles.Id);
            if (app == null)
            {
                await _applicationsRepo.AddAsync(new Application
                {
                    Id = Guid.NewGuid(),
                    JobTitlesId = payload.JobTitles.Id,
                    CreatedOn = DateTime.Now,
                    ApplicantsId = applicant.Id

                });
            }
        }

        private async Task<Applicant> checkIfUserAlreadyExists(string email)
        {
            var applicant = await _applicantRepo.GetByIdAsync(a => a.Email == email);
            return applicant;
        }

        private async Task<Application> checkIfApplicationAlreadyExists(Guid applicantId, Guid jobTitleId)
        {
            var application = await _applicationsRepo.GetByIdAsync(new List<Expression<Func<Application, bool>>> { a => a.ApplicantsId == applicantId, a => a.JobTitlesId == jobTitleId });
            return application;
        }

        public Task<EntityState> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<EntityState> Edit(Guid id, Application payload)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Application>> GetAll()
        {
            return await _applicationsRepo.GetAsync(predicates: new List<Expression<Func<Application, bool>>> { x => true }
            , x => x.OrderByDescending(a => a.CreatedOn)
            , includes: new List<Expression<Func<Application, object>>> { j => j.Applicants, j => j.JobTitles }, true);
        }

        public Task<Application> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
