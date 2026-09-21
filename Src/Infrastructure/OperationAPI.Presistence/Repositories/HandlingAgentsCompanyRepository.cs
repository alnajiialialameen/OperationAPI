using AutoMapper;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class HandlingAgentsCompanyRepository : GenericRepository<HandlingAgentsCompanyDomain, HandlingAgentsCompany> , IHandlingAgentsCompanyService
    {
        public HandlingAgentsCompanyRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
