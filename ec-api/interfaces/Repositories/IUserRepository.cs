using models;
using System.Threading.Tasks;

namespace interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetByEmail(string email);

        Task<User> GetById(int id);
    }
}
