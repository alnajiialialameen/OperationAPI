using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Application.Features.AircraftRegisteration.Command.DeleteAircraftRegisteration;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAllAircraftRegisteration;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftRegistrationController : ControllerBase
    {
        private readonly IMediator mediator;

        public AircraftRegistrationController(IMediator mediator)
        {
            this.mediator = mediator;
        }
       
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllAircraftRegisterationRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetAircraftRegisterationByIdRequest(id));

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AircraftRegistrationDomain model)
        {
            var data = await mediator.Send(new CreateAircraftRegistrationCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AircraftRegistrationDomain model)
        {
            var data = await mediator.Send(new UpdateAircraftRegistrationCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteAircraftRegisterationCommand(id));

            return Ok(data);
        }

    }
}
