using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.AcceptOfficer;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.ConfirmAgent;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.CreatelService;
using OperationAPI.Application.Features.ServiceRequestDetail.Command.UpdateService;
using OperationAPI.Application.Features.ServiceRequestDetail.Quieres.GetRequestDetailByTowerId;
using OperationAPI.Application.Features.TowerData.Command.UpdateTakeOffFlight;
using OperationAPI.Application.Features.TowerData.Quieres.GetFlightByStatus;
using OperationAPI.Domain;
namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRequestDetailController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceRequestDetailController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ServiceRequestDetailDomain model)
        {
            var data = await mediator.Send(new CreateServiceCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ServiceRequestDetailDomain model)
        {
            var data = await mediator.Send(new UpdateServiceCommand(model));

            return Ok(data);
        }


        [HttpGet("ServiceDetailByTowerId/{TowerId}")]
        public async Task<IActionResult> GetServiceDetailByTowerId(int TowerId)
        {
           
            var data = await mediator.Send(new GetRequestDetailByTowerIdRequest(TowerId));

            return Ok(data);
        }


        [HttpPut("ConfirmAgent")]
        public async Task<IActionResult> ConfirmAgent([FromBody] confirmServiceDetailDomain model)
        {
            var data = await mediator.Send(new ConfirmAgentCommand(model));
            return Ok(data);
        }

        [HttpPut("AcceptOfficer")]
        public async Task<IActionResult> AcceptOfficer([FromBody] confirmServiceDetailDomain model)
        {
            var data = await mediator.Send(new AcceptOfficerCommand(model));
            return Ok(data);
        }


    }
}
