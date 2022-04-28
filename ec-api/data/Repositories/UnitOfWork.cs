using interfaces.Repositories;
using persistence.Contexts;
using System.Threading.Tasks;

namespace persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        private readonly AppDbContext _context;
    }
}
