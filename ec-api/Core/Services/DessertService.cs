using core.Communication;
using interfaces.Services;
using interfaces.Repositories;
using models;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace core.Services
{
    public class DessertService : IDessertService<AppResponse<Dessert>>
    {
        private IRepository<Dessert> _dessertRepository;
        private IUnitOfWork _unitOfWork;
        
        public DessertService(IRepository<Dessert> dessertRepository, IUnitOfWork unitOfWork)
        {
            _dessertRepository = dessertRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Dessert>> ListAsync()
        {
            var tasks = await _dessertRepository.GetAllAsync();
            return tasks;
        }

        public async Task<AppResponse<Dessert>> SaveAsync(Dessert task)
        {
            try
            {
                await _dessertRepository.AddAsync(task);
                await _unitOfWork.CompleteAsync();

                return new AppResponse<Dessert>(task);
            }
            catch (Exception ex)
            {
                return new AppResponse<Dessert>($"{ex.Message}");
            }
        }
    }
}
