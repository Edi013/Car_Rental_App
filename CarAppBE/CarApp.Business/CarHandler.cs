using CarApp.Business.Entities;
using CarApp.Business.Interfaces;

namespace CarApp.Business
{
    public class CarHandler 
    {
        private IRepository<Car> repository;

        public CarHandler(IRepository<Car> _repository)
        {
            repository = _repository;
        }

        public Task<IEnumerable<Car>> GetAll()
        {
            return repository.GetAll();
        }

        public async Task<Car> GetById(long id)
        {
            return await repository.GetById(id);
        }

        public async Task<Car> Add(Car entity)
        {
            return await repository.Add(entity);
        }

        public async Task Delete(Car entity)
        {
            await repository.Delete(entity);
        }

        public async Task<Car> Update(Car entity)
        {
            return await repository.Update(entity);
        }
    }
}
