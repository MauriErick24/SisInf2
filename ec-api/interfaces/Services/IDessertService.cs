using models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace interfaces.Services
{
    public interface IDessertService<TEntity>
    {
        Task<IEnumerable<Dessert>> ListAsync();

        Task<TEntity> SaveAsync(Dessert task);
    }
}
