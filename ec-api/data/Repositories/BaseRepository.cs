using persistence.Contexts;

namespace persistence.Repositories
{
    public abstract class BaseRepository
    {
        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }

        protected readonly AppDbContext _context;
    }
}
