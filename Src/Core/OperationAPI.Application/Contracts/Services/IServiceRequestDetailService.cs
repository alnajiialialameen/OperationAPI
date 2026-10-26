using OperationAPI.Domain;

namespace OperationAPI.Application.Contracts.Services
{
   public interface IServiceRequestDetailService :IGenericService<ServiceRequestDetailDomain>
    {
        Task<ServiceRequestDetailDomain> CreatelService(ServiceRequestDetailDomain model); 

        Task<ServiceRequestDetailDomain> UpdateService(ServiceRequestDetailDomain model);

        Task<List<ServiceRequestDetailViewDomain>> GetIServiceRequestDetailServiceByTowerId(int? TowerId);


        Task<ServiceRequestDetailDomain> ConfirmAgent(confirmServiceDetailDomain model);
        Task<ServiceRequestDetailDomain> AcceptOfficer(confirmServiceDetailDomain model);

    }
}
