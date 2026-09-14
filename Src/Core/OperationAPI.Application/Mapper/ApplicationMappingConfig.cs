using AutoMapper;
using OperationAPI.Domain;

namespace OperationAPI.Application.Mapper
{
    public class ApplicationMappingConfig : Profile
    {
        public ApplicationMappingConfig()
        {
            CreateMap<DepartureServiceDomain, OfficerDataDomain>().ReverseMap();
            CreateMap<LandingServiceDomain, OfficerDataDomain>().ReverseMap();
        }
    }
}
