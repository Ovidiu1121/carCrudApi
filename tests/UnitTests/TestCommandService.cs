using System.Threading.Tasks;
using CarCrudApi.Cars.Repository.interfaces;
using CarCrudApi.Cars.Service;
using CarCrudApi.Cars.Service.Interfaces;
using CarCrudApi.Dto;
using CarCrudApi.System.Constant;
using CarCrudApi.System.Exceptions;
using Moq;
using tests.Helpers;
using Xunit;

namespace tests.UnitTests;

public class TestCommandService
{
    Mock<ICarRepository> _mock;
    ICarCommandService _service;

    public TestCommandService()
    {
        _mock = new Mock<ICarRepository>();
        _service = new CarCommandService(_mock.Object);
    }
    
    [Fact]
    public async Task Create_InvalidData()
    {
        var create = new CreateCarRequest()
        {
            Brand="test",
            Price=0,
            Horse_power= 0,
            Fabrication_year = 0
        };

        var car = TestCarFactory.CreateCar(5);

        _mock.Setup(repo => repo.GetByBrandAsync("test")).ReturnsAsync(car);
                
        var exception=  await Assert.ThrowsAsync<ItemAlreadyExists>(()=>_service.CreateCar(create));

        Assert.Equal(Constants.CAR_ALREADY_EXIST, exception.Message);
    }
    
    [Fact]
    public async Task Create_ReturnCar()
    {

        var create = new CreateCarRequest()
        {
            Brand="test",
            Price=1120,
            Horse_power= 300,
            Fabrication_year = 2023
        };

        var car=  TestCarFactory.CreateCar(5);

        car.Brand=create.Brand;
        car.Price=create.Price;
        car.Horse_power=create.Horse_power;
        car.Fabrication_year=create.Fabrication_year;

        _mock.Setup(repo => repo.CreateCar(It.IsAny<CreateCarRequest>())).ReturnsAsync(car);

        var result = await _service.CreateCar(create);

        Assert.NotNull(result);
        Assert.Equal(result, car);
    }
    
    [Fact]
    public async Task Update_ItemDoesNotExist()
    {
        var update = new UpdateCarRequest()
        {
            Brand="test",
            Price=1120,
            Horse_power= 300,
            Fabrication_year = 2023
        };

        _mock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _service.UpdateCar(1, update));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task Update_InvalidData()
    {
        var update = new UpdateCarRequest()
        {
            Brand="test",
            Price=0,
            Horse_power= 0,
            Fabrication_year = 0
        };

        _mock.Setup(repo=>repo.GetByIdAsync(1)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _service.UpdateCar(5, update));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task Update_ValidData()
    {
        var update = new UpdateCarRequest()
        {
            Brand="test",
            Price=1120,
            Horse_power= 300,
            Fabrication_year = 2023
        };

        var car = TestCarFactory.CreateCar(5);

        car.Brand=update.Brand;
        car.Price=update.Price.Value;
        car.Horse_power=update.Horse_power.Value;
        car.Fabrication_year=update.Fabrication_year.Value;

        _mock.Setup(repo => repo.GetByIdAsync(5)).ReturnsAsync(car);
        _mock.Setup(repoo => repoo.UpdateCar(It.IsAny<int>(), It.IsAny<UpdateCarRequest>())).ReturnsAsync(car);

        var result = await _service.UpdateCar(5, update);

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
    [Fact]
    public async Task Delete_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.DeleteCarById(It.IsAny<int>())).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _service.DeleteCar(5));

        Assert.Equal(exception.Message, Constants.CAR_DOES_NOT_EXIST);

    }
    
    [Fact]
    public async Task Delete_ValidData()
    {
        var car = TestCarFactory.CreateCar(1);

        _mock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(car);

        var result= await _service.DeleteCar(1);

        Assert.NotNull(result);
        Assert.Equal(car, result);


    }
    
}