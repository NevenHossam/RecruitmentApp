
namespace Recruitment_App.Services.IServices
{
    public interface IJobTitleService<T, TT> : IService<T, TT> where T : class
    {
        Task<IEnumerable<T>> GetAllAvailable();
    }
}
