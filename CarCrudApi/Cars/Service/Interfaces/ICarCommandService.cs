using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Cars.Service.Interfaces
{
    public interface ICarCommandService
    {
        Task<CarDto> CreateCar(CreateCarRequest request);
        Task<CarDto> UpdateCar(int id,UpdateCarRequest request);
        Task<CarDto> DeleteCar(int id);


    }
}
