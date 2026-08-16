using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftSize.Command.CreateAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetByIdAircraftSize;
using OperationAPI.Application.Features.AircraftType.Command.CreateAircraftType;
using OperationAPI.Application.Features.AircraftType.Command.DeleteAircraftType;
using OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType;
using OperationAPI.Application.Features.AircraftType.Quieres.GetAllAircraftType;
using OperationAPI.Application.Features.AircraftType.Quieres.GetByIdAircraftType;
using OperationAPI.Application.Features.WorkOn.Command.DeleteWorkOn;
using OperationAPI.Application.Features.WorkOn.Command.UpdateWorkOn;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public AircraftTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllAircraftTypeRequest());

            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await mediator.Send(new GetByIdAircraftTypeRequest(Id));
            return Ok(data);
        }




        [HttpPost]
        public async Task<IActionResult> post(AircraftTypeDomain modal)
        {
            var data = await mediator.Send(new CreateAircraftTypeCommand(modal));
            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteAircraftTypeCommand(id));

            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] AircraftTypeDomain model)
        {
            var data = await mediator.Send(new UpdateAircraftTypeCommand(model));

            return Ok(data);
        }

    }
}
