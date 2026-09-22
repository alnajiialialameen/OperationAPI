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
            CreateMap<AirLine, AirLineDomain>()
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.ArName))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();

            // AirPort
            CreateMap<AirPort, AirPortDomain>()
                .ForMember(dest => dest.NameAr, opt => opt.MapFrom(src => src.NameAr))
                .ForMember(dest => dest.NameEn, opt => opt.MapFrom(src => src.NameEn))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.CountryId, opt => opt.MapFrom(src => src.CountryId))
                .ForMember(dest => dest.CountryName, opt => opt.MapFrom(src => src.Country!.NameEn?? src.Country.NameAr))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ReverseMap();


            //AirLineAgent
            CreateMap<AirLineAgentDomain, AirLineAgent>().ReverseMap();
            /// put / post
            CreateMap<AirLineAgentDomain, AirLineAgent>()
               .ForMember(dest => dest.AirLine, opt => opt.Ignore());

            // get
            CreateMap<AirLineAgent, AirLineAgentDomain>()
              .ForMember(dest => dest.AirLineCode, opt => opt.MapFrom(src => src.AirLine!.Code))
              .ForMember(dest => dest.AirLineNameEn, opt => opt.MapFrom(src => src.AirLine!.Name))
              .ForMember(dest => dest.AirLineNameAr, opt => opt.MapFrom(src => src.AirLine!.ArName));

            CreateMap<TowerDatum, TowerDataDomain>().ReverseMap();
            CreateMap<OfficerDatum, OfficerDataDomain>().ReverseMap();

        }
    }
}
