using models;
using System.Threading.Tasks;

namespace interfaces.Services
{
    public interface IProductService<T>
    {
        Task<T> AddProduct(Product entity, string token);
    }
}
