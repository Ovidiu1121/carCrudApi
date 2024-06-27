using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Cars.Service.Interfaces
{
    public interface ICarQueryService
    {
            Task<ListCarDto> GetAllCar();
            Task<CarDto> GetByBrand(string brand);
            Task<CarDto> GetById(int id);
            Task<CarDto> GetByPrice(int price);
            Task<CarDto> GetByYear(int year);
            Task<CarDto> GetByHorsePower(int horsePower);

    }
}
