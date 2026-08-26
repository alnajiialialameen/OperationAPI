using AutoMapper;
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
    public class OfficerDataRepository : GenericRepository<OfficerDataDomain, OfficerDatum>, IOfficerDataService
    {
        public OfficerDataRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
