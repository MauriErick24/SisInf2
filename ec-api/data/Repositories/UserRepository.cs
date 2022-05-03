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

        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        public async Task<Seller> GetSellerByUserId(int userId)
        {
            return await _context.Sellers.SingleOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
