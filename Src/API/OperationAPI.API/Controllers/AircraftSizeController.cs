using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftRegisteration.Command.DeleteAircraftRegisteration;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Command.DeleteAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Command.UpdateAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetByIdAircraftSize;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftSizeController : ControllerBase
    {
        private readonly IMediator mediator;

         public AircraftSizeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllAircraftSizeRequest());

            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await mediator.Send(new GetByIdAircraftSizeRequest(Id));
            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> post(AircraftSizeDomain modal)
        {
            var data = await mediator.Send(new CreateAircraftSizeCommand(modal));
            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> Put(AircraftSizeDomain model)
        {
            var data = await mediator.Send(new UpdateAircraftSizeCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteAircraftSizeCommand(id));

            return Ok(data);
        }
    }
}
