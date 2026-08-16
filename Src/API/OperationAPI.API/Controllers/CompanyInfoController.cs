using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Application.Features.AircraftRegisteration.Command.DeleteAircraftRegisteration;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Application.Features.AircraftRegisteration.Quieres.GetAircraftRegisterationById;
using OperationAPI.Application.Features.CompanyInfo.Command.CreateCompanyInfo;
using OperationAPI.Application.Features.CompanyInfo.Command.DeleteCompanyInfo;
using OperationAPI.Application.Features.CompanyInfo.Command.UpdateCompanyInfo;
using OperationAPI.Application.Features.CompanyInfo.Quieres.GetAllCompanyInfo;
using OperationAPI.Application.Features.CompanyInfo.Quieres.GetByIdCompanyInfo;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyInfoController : ControllerBase
    {
        private readonly IMediator mediator;

        public CompanyInfoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllCompanyInfoRequest());

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetByIdCompanyInfoRequest(id));

            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CompanyInfoDomain model)
        {
            var data = await mediator.Send(new CreateCompanyInfoCommand(model));

            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CompanyInfoDomain model)
        {
            var data = await mediator.Send(new UpdateCompanyInfoCommand(model));

            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteCompanyInfoCommand(id));

            return Ok(data);
        }
    }
}
