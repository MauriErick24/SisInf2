using models;
using System.Threading.Tasks;

namespace interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        User GetById(int id);

        Task<Seller> GetSellerByUserId(int userId);
    }
}
