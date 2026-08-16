using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.HandlingAgentsCompany.Command.CreateHandlingAgentsCompany;
using OperationAPI.Application.Features.HandlingAgentsCompany.Command.DeleteHandlingAgentsCompany;
using OperationAPI.Application.Features.HandlingAgentsCompany.Command.UpdateHandlingAgentsCompany;
using OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetAllHandlingAgentsCompany;
using OperationAPI.Application.Features.HandlingAgentsCompany.Quieres.GetByIdHandlingAgentsCompany;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HandlingAgentsCompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public HandlingAgentsCompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllHandlingAgentsCompanyRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetByIdHandlingAgentsCompanyRequest(id));

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] HandlingAgentsCompanyDomain model)
        {
            var data = await mediator.Send(new CreateHandlingAgentsCompanyCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] HandlingAgentsCompanyDomain model)
        {
            var data = await mediator.Send(new UpdateHandlingAgentsCompanyCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteHandlingAgentsCompanyCommand(id));

            return Ok(data);
        }
    }
}
