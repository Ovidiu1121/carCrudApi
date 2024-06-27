using CarCrudApi.Cars.Controllers.Interfaces;
using CarCrudApi.Cars.Model;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CarCrudApi.Cars.Controllers
{
    public class CarController:CarApiController
    {
        private ICarCommandService _carCommandService;
        private ICarQueryService _carQueryService;

        public CarController(ICarCommandService carCommandService, ICarQueryService carQueryService)
        {
            _carCommandService = carCommandService;
            _carQueryService = carQueryService;
        }

        public override async Task<ActionResult<CarDto>> CreateCar([FromBody] CreateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.CreateCar(request);

                return Created("Masina a fost adaugata",cars);
            }
            catch (ItemAlreadyExists ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> DeleteCar([FromRoute] int id)
        {
            try
            {
                var cars = await _carCommandService.DeleteCar(id);

                return Accepted("", cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<ListCarDto>> GetAll()
        {
            try
            {
                var cars = await _carQueryService.GetAllCar();
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByBrandRoute([FromRoute] string brand)
        {
            try
            {
                var cars = await _carQueryService.GetByBrand(brand);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByIdRoute(int id)
        {
            try
            {
                var cars = await _carQueryService.GetById(id);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByPriceRoute(int price)
        {
            try
            {
                var cars = await _carQueryService.GetByPrice(price);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByYearRoute(int year)
        {
            try
            {
                var cars = await _carQueryService.GetByYear(year);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> GetByHorsePowerRoute(int horse_power)
        {
            try
            {
                var cars = await _carQueryService.GetByHorsePower(horse_power);
                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }

        public override async Task<ActionResult<CarDto>> UpdateCar([FromRoute]int id, [FromBody] UpdateCarRequest request)
        {
            try
            {
                var cars = await _carCommandService.UpdateCar(id,request);

                return Ok(cars);
            }
            catch (ItemDoesNotExist ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
