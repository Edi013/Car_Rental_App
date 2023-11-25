using CarApp.Business;
using CarApp.Business.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CarApp.Controllers
{
    [ApiController]
    [Route("/Api/[controller]")]
    public class CarController : Controller
    {
        private CarHandler handler;

        public CarController(CarHandler handler)
        {
            this.handler = handler;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<Car>> GetAll()
        {
            var result = await handler.GetAll();
            return result;
        }

        [HttpGet("GetById/{id}")]
        public async Task<Car> GetById(int id)
        {
            return await handler.GetById(id);
        }

        [HttpPost("Add")]
        public async Task<Car> Add(Car entity)
        {
            return await handler.Add(entity);
        }

        [HttpPut("Update")]
        public async Task<Car> Update(Car entity)
        {
            return await handler.Update(entity);
        }

        [HttpDelete("Delete/{id}")]
        public async Task Delete(int id)
        {
            await handler.Delete(id);
        }
    }
}
