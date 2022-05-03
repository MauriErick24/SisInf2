using models;
using System.Threading.Tasks;

namespace interfaces.Services
{
    public interface IProductService<T, E>
    {
        Task<T> AddProduct(Product entity, string token);

        Task<E> ListProducts();

        Task<E> ListProducts(int pageNumber, int pageSize);
    }
}
