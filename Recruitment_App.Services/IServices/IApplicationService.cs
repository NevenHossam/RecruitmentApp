
using Microsoft.EntityFrameworkCore;

namespace Recruitment_App.Services.IServices
{
    public interface IApplicationService<T, TT> : IService<T, TT> where T : class
    {
        Task Apply(T payload);
    }
}
