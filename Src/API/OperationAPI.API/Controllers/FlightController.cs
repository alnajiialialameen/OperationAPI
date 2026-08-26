using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.OfficerData.Command.CreateOfficerData;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlightController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> post(OfficerDataDomain modal)
        {
            var data = await mediator.Send(new CreateOfficerDataCommand(modal));
            return Ok(data);
        }
    }
}
