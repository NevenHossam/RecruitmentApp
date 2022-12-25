using Microsoft.EntityFrameworkCore;
using Recruitment_App.Repo.Context;
using Recruitment_App.Repo.Entities;
using Recruitment_App.Repo.IRepos;
using Recruitment_App.Repo.Repos;
using Recruitment_App.Services.IServices;
using Recruitment_App.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Register Services
builder.Services.AddDbContext<RecruitmentContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("RecruitmentContextConnectionString")));
builder.Services.AddScoped(typeof(IRepository<,>), typeof(RepositoryBase<,>));

builder.Services.AddScoped<IService<Applicant, Guid>, ApplicantService>();
builder.Services.AddScoped<IService<JobTitle, Guid>, JobTitleService>();
builder.Services.AddScoped<IJobTitleService<JobTitle, Guid>, JobTitleService>();
builder.Services.AddScoped<IService<Skill, int>, SkillService>();
builder.Services.AddScoped<IService<JobCategory, int>, JobCategoryService>();
builder.Services.AddScoped<IService<Application, Guid>, ApplicationService>();
builder.Services.AddScoped<IApplicationService<Application, Guid>, ApplicationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
