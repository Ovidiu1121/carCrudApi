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

public class TestQueryService
{
    Mock<ICarRepository> _mock;
    ICarQueryService _service;

    public TestQueryService()
    {
        _mock=new Mock<ICarRepository>();
        _service=new CarQueryService(_mock.Object);
    }
    
    [Fact]
    public async Task GetAll_ItemsDoNotExist()
    {
        _mock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(new ListCarDto());

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _service.GetAllCar());

        Assert.Equal(exception.Message, Constants.NO_CAR_EXIST);       

    }
    
    [Fact]
    public async Task GetAll_ReturnAllCars()
    {

        var cars = TestCarFactory.CreateCars(5);

        _mock.Setup(repo=>repo.GetAllAsync()).ReturnsAsync(cars);

        var result = await _service.GetAllCar();

        Assert.NotNull(result);
        Assert.Contains(cars.carList[1], result.carList);

    }
    
    [Fact]
    public async Task GetById_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(()=>_service.GetById(1));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task GetById_ReturnCar()
    {

        var car = TestCarFactory.CreateCar(5);

        _mock.Setup(repo => repo.GetByIdAsync(5)).ReturnsAsync(car);

        var result = await _service.GetById(5);

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
    [Fact]
    public async Task GetByBrand_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.GetByBrandAsync("")).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(() => _service.GetByBrand(""));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task GetByBrand_ReturnCar()
    {

        var car=TestCarFactory.CreateCar(3);

        car.Brand="test";

        _mock.Setup(repo => repo.GetByBrandAsync("test")).ReturnsAsync(car);

        var result = await _service.GetByBrand("test");

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
    [Fact]
    public async Task GetByPrice_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.GetByPriceAsync(100)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(()=>_service.GetByPrice(100));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task GetByPrice_ReturnCar()
    {

        var car = TestCarFactory.CreateCar(5);

        _mock.Setup(repo => repo.GetByPriceAsync(2000)).ReturnsAsync(car);

        var result = await _service.GetByPrice(2000);

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
    [Fact]
    public async Task GetByHorsePower_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.GetByHorsePowerAsync(350)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(()=>_service.GetByHorsePower(350));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task GetByHorsePower_ReturnCar()
    {

        var car = TestCarFactory.CreateCar(5);

        _mock.Setup(repo => repo.GetByHorsePowerAsync(450)).ReturnsAsync(car);

        var result = await _service.GetByHorsePower(450);

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
    [Fact]
    public async Task GetByYear_ItemDoesNotExist()
    {

        _mock.Setup(repo => repo.GetByYearAsync(2008)).ReturnsAsync((CarDto)null);

        var exception = await Assert.ThrowsAsync<ItemDoesNotExist>(()=>_service.GetByYear(2008));

        Assert.Equal(Constants.CAR_DOES_NOT_EXIST, exception.Message);

    }
    
    [Fact]
    public async Task GetByYear_ReturnCar()
    {

        var car = TestCarFactory.CreateCar(5);

        _mock.Setup(repo => repo.GetByYearAsync(1997)).ReturnsAsync(car);

        var result = await _service.GetByYear(1997);

        Assert.NotNull(result);
        Assert.Equal(car, result);

    }
    
}