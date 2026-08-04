using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Presistence.Repositories
{
    public class AircraftSizeRepository : GenericRepository<AircraftSizeDomain, AircraftSize>, IAircraftSizeService
    {
        public AircraftSizeRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

      

  
      
    }
}
