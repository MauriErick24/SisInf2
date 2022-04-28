using interfaces.Repositories;
using models;
using persistence.Contexts;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace persistence.Repositories
{
    public class DessertRepository : BaseRepository, IRepository<Dessert>
    {
        public DessertRepository(AppDbContext context) : base(context) { }
        
        public async Task AddAsync(Dessert entity)
        {
            var dessert = _context.Desserts.FirstOrDefaultAsync(x => x.Name == entity.Name);
            if (dessert.Result is null)
            {
                //var lastDessert = _context.Desserts.OrderBy(x => x.Id).ToListAsync();
                //if (lastDessert is not null)
                //{
                //    entity.Id = lastDessert.Id + 1;
                //}
                //else
                //{
                //    entity.Id = 1;
                //}
                await _context.Desserts.AddAsync(entity);
            }
            else
            {
                throw new Exception("Dessert already exists!");
            }
        }

        public async Task<IEnumerable<Dessert>> GetAllAsync()
        {
            var desserts = await _context.Desserts.ToListAsync();
            return desserts;
        }
    }
}
