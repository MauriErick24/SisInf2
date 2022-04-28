using System.Threading.Tasks;

namespace interfaces.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
