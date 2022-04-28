using System.Collections.Generic;
using System.Threading.Tasks;

namespace interfaces.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        
        Task AddAsync(TEntity entity);
    }
}
