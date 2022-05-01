using core.Communication;
using interfaces.Repositories;
using interfaces.Services;
using models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Services
{
    public class ProductService : IProductService<AppResponse<Product>>
    {
        private IRepository<Product> _productRepository;

        private IUserRepository _userRepository;

        private IUnitOfWork _unitOfWork;

        public ProductService(IRepository<Product> productRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AppResponse<Product>> AddProduct(Product entity, string token)
        {
            var userId = Helper.GetUserId(token);

            if (userId == 0) 
            {
                return new AppResponse<Product>("Invalid user!");
            }
            else if (
                    string.IsNullOrEmpty(entity.Name)
                    || string.IsNullOrEmpty(entity.Description)
                    || entity.Description.Length > 255
                    || entity.Price == 0)
            {
                return new AppResponse<Product>("Invalid product!");
            }
            else
            {
                
                var seller = await _userRepository.GetSellerByUserId(userId);
                entity.SellerId = seller.Id;

                try
                {
                    await _productRepository.AddAsync(entity);
                    await _unitOfWork.CompleteAsync();

                    return new AppResponse<Product>(entity);
                }
                catch (Exception ex)
                {
                    return new AppResponse<Product>($"{ex.Message}");
                }
            }
        }
    }
}
