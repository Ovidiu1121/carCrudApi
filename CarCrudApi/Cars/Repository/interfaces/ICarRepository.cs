using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Cars.Repository.interfaces
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllAsync();
        Task<Car> GetByBrandAsync(string brand);
        Task<Car> GetByIdAsync(int id);
        Task<Car> CreateCar(CreateCarRequest request);
        Task<Car> UpdateCar(int id,UpdateCarRequest request);
        Task<Car> DeleteCarById(int id);

    }
}
