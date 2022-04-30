using models;
using System.Threading.Tasks;

namespace interfaces.Services
{
    public interface IUserService<T>
    {
        Task<T> Login(UserPassword user);
    }
}
