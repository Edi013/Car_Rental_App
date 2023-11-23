using CarApp.Business.Entities;
using CarApp.Business.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarApp.DataAccess.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private ApplicationDbContext context;

        public CarRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<Car> Add(Car entity)
        {
            await context.Set<Car>().AddAsync(entity);
            await context.SaveChangesAsync();

            return entity;
        }

        public async Task Delete(Car entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await context.Set<Car>().ToListAsync();
        }

        public async Task<Car> GetById(int id)
        {
            return await context.Set<Car>().FindAsync(id);
        }

        public async Task<Car> Update(Car entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
