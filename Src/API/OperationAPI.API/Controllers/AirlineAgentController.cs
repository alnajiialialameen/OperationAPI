using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Application.Features.AirLineAgent.Command;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirlineAgentController : ControllerBase
    {
        private readonly IMediator mediator;

        public AirlineAgentController(IMediator mediator) 
        { 
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirLineAgentDomain model)
        {
            var data = await mediator.Send(new AirLineAgentCommand(model));

            return Ok(data);
        }

    }
}
