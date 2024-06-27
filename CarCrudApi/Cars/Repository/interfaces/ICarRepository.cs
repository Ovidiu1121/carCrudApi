using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Cars.Repository.interfaces
{
    public interface ICarRepository
    {
        Task<ListCarDto> GetAllAsync();
        Task<CarDto> GetByBrandAsync(string brand);
        Task<CarDto> GetByIdAsync(int id);
        Task<CarDto> GetByPriceAsync(int price);
        Task<CarDto> GetByHorsePowerAsync(int horse_power);
        Task<CarDto> GetByYearAsync(int fabrication_year);
        Task<CarDto> CreateCar(CreateCarRequest request);
        Task<CarDto> UpdateCar(int id,UpdateCarRequest request);
        Task<CarDto> DeleteCarById(int id);

    }
}
