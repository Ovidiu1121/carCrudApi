using AutoMapper;
using CarCrudApi.Cars.Model;
using CarCrudApi.Dto;

namespace CarCrudApi.Mappings
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateCarRequest, Car>();
            CreateMap<UpdateCarRequest, Car>();
        }

    }
}
