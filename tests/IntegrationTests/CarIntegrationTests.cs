﻿using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;
using Newtonsoft.Json;
using tests.Infrastructure;
using Xunit;

namespace tests.IntegrationTests;

public class CarIntegrationTests: IClassFixture<ApiWebApplicationFactory>
{
    private readonly HttpClient _client;

    public CarIntegrationTests(ApiWebApplicationFactory factory)
    {
        _client = factory.CreateClient();
    }
    
    
    [Fact]
    public async Task Post_Create_ValidRequest_ReturnsCreatedStatusCode_ValidProductContentResponse()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);

        Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString);

        Assert.NotNull(result);
        Assert.Equal(car.Brand, result.Brand);
        Assert.Equal(car.Price, result.Price);
        Assert.Equal(car.Horse_power, result.Horse_power);
        Assert.Equal(car.Fabrication_year, result.Fabrication_year);
    }
    
    [Fact]
    public async Task Post_Create_CarAlreadyExists_ReturnsBadRequestStatusCode()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        await _client.PostAsync(request, content);
        var response = await _client.PostAsync(request, content);

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }
    
    [Fact]
    public async Task Put_Update_ValidRequest_ReturnsAcceptedStatusCode_ValidProductContentResponse()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString)!;

        request = "/api/v1/Car/update/"+result.Id;
        var updateCar = new UpdateCarRequest()
            { Brand = "updated brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        content = new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json");

        response = await _client.PutAsync(request, content);
        
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);

        responseString = await response.Content.ReadAsStringAsync();
        result = JsonConvert.DeserializeObject<Car>(responseString)!;

        Assert.Equal(updateCar.Brand, result.Brand);
        Assert.Equal(updateCar.Price, result.Price);
        Assert.Equal(updateCar.Horse_power, result.Horse_power);
        Assert.Equal(updateCar.Fabrication_year, result.Fabrication_year);
        
    }
    
    [Fact]
    public async Task Put_Update_CarDoesNotExists_ReturnsNotFoundStatusCode()
    {
        
        var request = "/api/v1/Car/update/1";
        var updateCar= new UpdateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(updateCar), Encoding.UTF8, "application/json");

        var response = await _client.PutAsync(request, content);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
    [Fact]
    public async Task Delete_Delete_CarExists_ReturnsDeletedCar()
    {

        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString)!;

        request = "/api/v1/Car/delete/" + result.Id;
        response = await _client.DeleteAsync(request);
        
        Assert.Equal(HttpStatusCode.Accepted,response.StatusCode);
    }
    
    [Fact]
    public async Task Delete_Delete_CarDoesNotExists_ReturnsNotFoundStatusCode()
    {

        var request = "/api/v1/Car/delete/1";

        var response = await _client.DeleteAsync(request);

        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
    [Fact]
    public async Task Get_GetById_ValidRequest_ReturnsOKStatusCode()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString);

        request = "/api/v1/Car/id/" + result.Id;
        response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
    
    [Fact]
    public async Task Get_GetById_CarDoesExists_ReturnsNotFoundStatusCode()
    {
        
        var request = "/api/v1/Car/id/1";

        var response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
    [Fact]
    public async Task Get_GetByBrand_ValidRequest_ReturnsOKStatusCode()
    {

        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString)!;

        request = "/api/v1/Car/brand/" + result.Brand;
        response = await _client.GetAsync(request);

        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
    
    [Fact]
    public async Task Get_GetByBrand_CarrDoesNotExists_ReturnsNotFoundStatusCode()
    {

        var request = "/api/v1/Car/brand/test";

        var response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);

    }
    
    [Fact]
    public async Task Get_GetByPrice_ValidRequest_ReturnsOKStatusCode()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString);

        request = "/api/v1/Car/price/" + result.Price;
        response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
    
    [Fact]
    public async Task Get_GetByPrice_CarDoesExists_ReturnsNotFoundStatusCode()
    {
        
        var request = "/api/v1/Car/price/4300";

        var response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
    [Fact]
    public async Task Get_GetByYear_ValidRequest_ReturnsOKStatusCode()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString);

        request = "/api/v1/Car/year/" + result.Fabrication_year;
        response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
    
    [Fact]
    public async Task Get_GetByYear_CarDoesExists_ReturnsNotFoundStatusCode()
    {
        
        var request = "/api/v1/Car/year/1700";

        var response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
    [Fact]
    public async Task Get_GetByHorsePower_ValidRequest_ReturnsOKStatusCode()
    {
        var request = "/api/v1/Car/create";
        var car = new CreateCarRequest()
            { Brand = "new brand", Price = 300, Horse_power = 400, Fabrication_year = 2023 };
        var content = new StringContent(JsonConvert.SerializeObject(car), Encoding.UTF8, "application/json");

        var response = await _client.PostAsync(request, content);
        var responseString = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<Car>(responseString);

        request = "/api/v1/Car/horse_power/" + result.Horse_power;
        response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.OK,response.StatusCode);
    }
    
    [Fact]
    public async Task Get_GetByHorsePower_CarDoesExists_ReturnsNotFoundStatusCode()
    {
        
        var request = "/api/v1/Car/horse_power/200";

        var response = await _client.GetAsync(request);
        
        Assert.Equal(HttpStatusCode.NotFound,response.StatusCode);
        
    }
    
}