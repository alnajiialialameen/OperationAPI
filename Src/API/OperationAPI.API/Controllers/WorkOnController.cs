using MediatR;
using Microsoft.AspNetCore.Mvc;

using OperationAPI.Application.Features.WorkOn.Command.CreateWorkOn;
using OperationAPI.Application.Features.WorkOn.Command.DeleteWorkOn;
using OperationAPI.Application.Features.WorkOn.Command.UpdateWorkOn;
using OperationAPI.Application.Features.WorkOn.Quieres.GetAllWorkOn;
using OperationAPI.Application.Features.WorkOn.Quieres.GetWorkOnById;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOnController : ControllerBase
    {
        private readonly IMediator mediator;

        public WorkOnController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllWorkOnRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetWorkOnByIdRequest(id));

            return Ok(data);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] WorkOnDomain model)
        {
            var data = await mediator.Send(new CreateWorkOnCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] WorkOnDomain model)
        {
            var data = await mediator.Send(new UpdateWorkOnCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteWorkOnCommand(id));

            return Ok(data);
        }

    }
}
