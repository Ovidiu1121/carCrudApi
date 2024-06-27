using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;
using Microsoft.AspNetCore.Mvc;

namespace CarCrudApi.Cars.Controllers.Interfaces
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class CarApiController: ControllerBase
    {

        [HttpGet("all")]
        [ProducesResponseType(statusCode: 200, type: typeof(IEnumerable<Car>))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<ListCarDto>> GetAll();

        [HttpPost("create")]
        [ProducesResponseType(statusCode: 201, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> CreateCar([FromBody] CreateCarRequest request);

        [HttpPut("update/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 400, type: typeof(String))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> UpdateCar([FromRoute]int id, [FromBody] UpdateCarRequest request);

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> DeleteCar([FromRoute] int id);

        [HttpGet("brand/{brand}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> GetByBrandRoute([FromRoute] string brand);
        
        [HttpGet("id/{id}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> GetByIdRoute([FromRoute] int id);
        
        [HttpGet("price/{price}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> GetByPriceRoute([FromRoute] int price);
        
        [HttpGet("year/{year}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> GetByYearRoute([FromRoute] int year);
        
        [HttpGet("horse_power/{horse_power}")]
        [ProducesResponseType(statusCode: 202, type: typeof(Car))]
        [ProducesResponseType(statusCode: 404, type: typeof(String))]
        public abstract Task<ActionResult<CarDto>> GetByHorsePowerRoute([FromRoute] int horse_power);

    }
}
