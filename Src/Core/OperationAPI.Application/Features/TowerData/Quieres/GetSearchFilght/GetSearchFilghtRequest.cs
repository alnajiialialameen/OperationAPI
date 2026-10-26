using MediatR;
using OperationAPI.Application.Models;
using OperationAPI.Domain;
namespace OperationAPI.Application.Features.TowerData.Quieres.GetSearchFilght
{
  
    public class GetSearchFilghtRequest : IRequest<List<TowerDataViewDomain>>
    {
        public FlightSearchRequestModel model;

        public GetSearchFilghtRequest(FlightSearchRequestModel model)
        {
            this.model = model;
        }
    }






}
