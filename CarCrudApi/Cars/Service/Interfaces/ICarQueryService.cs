using CarCrudApi.Cars.Model;

namespace CarCrudApi.Cars.Service.Interfaces
{
    public interface ICarQueryService
    {
        Task<IEnumerable<Car>> GetAllCar();
        Task<Car> GetByBrand(string brand);
        Task<Car> GetById(int id);

    }
}
