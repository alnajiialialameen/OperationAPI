using AutoMapper;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.MapperConfig
{
  public  class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<AircraftSizeDomain, AircraftSize>().ReverseMap();
            CreateMap<AircraftRegistrationDomain, AircraftRegistration>().ReverseMap();
            CreateMap<WorkOn, WorkOnDomain>().ReverseMap();
            CreateMap<CompanyInfo, CompanyInfoDomain>().ReverseMap();
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();

        }
    }
}
