using CarCrudApi.Dto;

namespace tests.Helpers;

public class TestCarFactory
{
    public static CarDto CreateCar(int id)
    {
        return new CarDto
        {
            Id = id,
            Brand="BMW"+id,
            Price=45000+id,
            Horse_power=30+id,
            Fabrication_year=2003+id
        };
    }

    public static ListCarDto CreateCars(int count)
    {
        ListCarDto cars=new ListCarDto();
            
        for(int i = 0; i<count; i++)
        {
            cars.carList.Add(CreateCar(i));
        }
        return cars;
    }
}