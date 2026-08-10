using AutoMapper;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        }
    }
}
