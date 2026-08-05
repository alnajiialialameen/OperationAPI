using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize;
using OperationAPI.Application.Features.AirLineAgent.Quieres.GetAllAirLineAgent;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirLineAgentController : ControllerBase
    {
        private readonly IMediator mediator;
        public AirLineAgentController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllAirLineAgentRequest());

            return Ok(data);
        }
    }
}
