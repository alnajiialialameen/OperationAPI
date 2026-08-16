using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.AircraftSize.Quieres.GetAllAircraftSize;
using OperationAPI.Application.Features.AircraftType.Command.CreateAircraftType;
using OperationAPI.Application.Features.AircraftType.Command.DeleteAircraftType;
using OperationAPI.Application.Features.AircraftType.Command.UpdateAircraftType;
using OperationAPI.Application.Features.AircraftType.Quieres.GetByIdAircraftType;
using OperationAPI.Application.Features.Country.Command.CreateCountry;
using OperationAPI.Application.Features.Country.Command.DeleteCountry;
using OperationAPI.Application.Features.Country.Command.UpdateCountry;
using OperationAPI.Application.Features.Country.Quieres.GetAllCountry;
using OperationAPI.Application.Features.Country.Quieres.GetByIdCountry;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator mediator;

        public CountryController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllCountryRequest());

            return Ok(data);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var data = await mediator.Send(new GetByIdCountryRequest(Id));
            return Ok(data);
        }



        [HttpPost]
        public async Task<IActionResult> post(CountryDomain modal)
        {
            var data = await mediator.Send(new CreateCountryCommand(modal));
            return Ok(data);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteCountryCommand(id));

            return Ok(data);
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CountryDomain model)
        {
            var data = await mediator.Send(new UpdateCountryCommand(model));

            return Ok(data);
        }


    }
}
