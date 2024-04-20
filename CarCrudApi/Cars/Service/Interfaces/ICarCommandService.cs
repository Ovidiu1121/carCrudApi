using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Cars.Service.Interfaces
{
    public interface ICarCommandService
    {
        Task<Car> CreateCar(CreateCarRequest request);
        Task<Car> UpdateCar(int id,UpdateCarRequest request);
        Task<Car> DeleteCar(int id);


    }
}
