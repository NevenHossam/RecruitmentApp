using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Recruitment_App.Services.IServices
{
    public interface IService<T, TT> where T : class 
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Add(T payload);
        Task<T> GetById(TT id);
        Task<EntityState> Edit(TT id, T payload);
        Task<EntityState> Delete(TT id);
    }
}
