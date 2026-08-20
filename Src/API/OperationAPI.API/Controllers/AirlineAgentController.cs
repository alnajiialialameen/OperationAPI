using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAllAircraftRegisteration;
using OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType;
using OperationAPI.Application.Features.AirLineAgent.Command.CreateAirLineAgent;
using OperationAPI.Application.Features.AirLineAgent.Command.UpdateAirLineAgent;
using OperationAPI.Application.Features.AirLineAgent.Quieres.GetAirLineAgentById;
using OperationAPI.Application.Features.AirLineAgent.Quieres.GetAllAirLineAgent;
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




        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllAirLineAgentRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetAirLineAgentByIdRequest(id));

            return Ok(data);
        }








        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AirLineAgentDomain model)
        {
            var data = await mediator.Send(new CreateAirLineAgentCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AirLineAgentDomain model)
        {
            var data = await mediator.Send(new UpdateAirLineAgentCommand(model));

            return Ok(data);
        }

    }
}
