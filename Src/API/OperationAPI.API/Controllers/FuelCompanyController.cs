using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.FuelCompany.Command.CreateFuelCompany;
using OperationAPI.Application.Features.FuelCompany.Command.DeleteFuelCompany;
using OperationAPI.Application.Features.FuelCompany.Command.UpdateFuelCompany;
using OperationAPI.Application.Features.FuelCompany.Quieres.GetAllFuelCompany;
using OperationAPI.Application.Features.FuelCompany.Quieres.GetFuelCompanyById;

using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelCompanyController : ControllerBase
    {
        private readonly IMediator mediator;

        public FuelCompanyController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllFuelCompanyRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetFuelCompanyByIdRequest(id));

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FuelCompanyDomain model)
        {
            var data = await mediator.Send(new CreateFuelCompanyCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FuelCompanyDomain model)
        {
            var data = await mediator.Send(new UpdateFuelCompanyCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteFuelCompanyCommand(id));

            return Ok(data);
        }
    }
}
