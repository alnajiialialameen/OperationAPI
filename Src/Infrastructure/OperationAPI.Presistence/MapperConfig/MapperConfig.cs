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

            CreateMap<WorkOn, WorkOnDomain>().ReverseMap();
            CreateMap<CompanyInfo, CompanyInfoDomain>().ReverseMap();
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();

            CreateMap<CountryDomain, Country>().ReverseMap();
           
            CreateMap<HandlingAgentsCompanyDomain, HandlingAgentsCompany>().ReverseMap();

            ///عند الإضافة (Domain → Entity) يتم تجاهل Size
            CreateMap<AircraftTypeDomain, AircraftType>().ForMember(dest => dest.Size, opt => opt.Ignore());
            CreateMap<AircraftType, AircraftTypeDomain>();


            ///AircraftRegistration
            ///عند الإضافة (Domain → Entity) يتم تجاهل AircraftType ,AireLine
            ///put / post

            CreateMap<AircraftRegistrationDomain, AircraftRegistration>()
                .ForMember(dest => dest.AircraftType, opt => opt.Ignore());
                //.ForMember(dest => dest.AireLine, opt => opt.Ignore());

            // Get
            CreateMap<AircraftRegistration, AircraftRegistrationDomain>()
                .ForMember(dest => dest.AircraftType, opt => opt.MapFrom(src => src.AircraftType));
            //.ForMember(dest => dest.AireLine, opt => opt.MapFrom(src => src.AireLine));
            // AirLine
            CreateMap<AirLine, AirLineDomain>();


            //AirLineAgent
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();
            /// put / post
            CreateMap<AirLineAgentDomain, AirLineAgent>()
               .ForMember(dest => dest.AirLine, opt => opt.Ignore());

            // get
            CreateMap<AirLineAgent, AirLineAgentDomain>()
              .ForMember(dest => dest.AirLine, opt => opt.MapFrom(src => src.AirLine));

        }
    }
}
