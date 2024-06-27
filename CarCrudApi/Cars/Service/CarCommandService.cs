using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Constant;
using CarCrudApi.System.Exceptions;

namespace CarCrudApi.Cars.Service
{
    public class CarCommandService:ICarCommandService
    {
        private ICarRepository _repository;

        public CarCommandService(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<CarDto> CreateCar(CreateCarRequest request)
        {
            CarDto car = await _repository.GetByBrandAsync(request.Brand);

            if (car!=null)
            {
                throw new ItemAlreadyExists(Constants.CAR_ALREADY_EXIST);
            }

            car=await _repository.CreateCar(request);
            return car;
        }

        public async Task<CarDto> DeleteCar(int id)
        {
            CarDto car = await _repository.GetByIdAsync(id);

            if (car==null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            await _repository.DeleteCarById(id);

            return car;
        }

        public async Task<CarDto> UpdateCar(int id,UpdateCarRequest request)
        {
            CarDto car = await _repository.GetByIdAsync(id);

            if (car==null)
            {
                throw new ItemDoesNotExist(Constants.CAR_DOES_NOT_EXIST);
            }

            car = await _repository.UpdateCar(id,request);
            return car;
        }
    }
}
