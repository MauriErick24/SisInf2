using interfaces.Repositories;
using models;
using persistence.Contexts;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace persistence.Repositories
{
    public class UserRepository: BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context): base(context) { }

        public async Task<User> GetByEmail(string email)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetById(int id)
        {
            return await _context.Users.SingleOrDefaultAsync(x => x.Id == id);
        }
    }
}
