using interfaces.Repositories;
using persistence.Contexts;
using models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace persistence.Repositories
{
    public class ProductRepository : BaseRepository, IRepository<Product>
    {
        public ProductRepository(AppDbContext context): base(context) { }

        public async Task AddAsync(Product entity)
        {
            await _context.Products.AddAsync(entity);
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
