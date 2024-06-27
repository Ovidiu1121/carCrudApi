using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Constant;
using CarCrudApi.System.Exceptions;

namespace CarCrudApi.Cars.Service
{
    public class CarQueryService:ICarQueryService
    {
        private ICarRepository _repository;

        public CarQueryService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<ListCarDto> GetAllCar()
        {
            ListCarDto cars = await _repository.GetAllAsync();

            if (cars.carList.Count().Equals(0))
            {
                throw new ItemDoesNotExist(Constants.NO_CAR_EXIST);
            }

            return cars;
        }

        public async Task<CarDto> GetByBrand(string brand)
        {
            CarDto car = await _repository.GetByBrandAsync(brand);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<CarDto> GetByPrice(int price)
        {
            CarDto car = await _repository.GetByPriceAsync(price);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<CarDto> GetByYear(int year)
        {
            CarDto car = await _repository.GetByYearAsync(year);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<CarDto> GetByHorsePower(int horsePower)
        {
            CarDto car = await _repository.GetByHorsePowerAsync(horsePower);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }

        public async Task<CarDto> GetById(int id)
        {
            CarDto car = await _repository.GetByIdAsync(id);

            if (car == null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            return car;
        }
    }
}
