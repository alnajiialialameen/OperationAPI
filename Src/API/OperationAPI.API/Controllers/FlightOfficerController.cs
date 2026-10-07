using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.OfficerData.Command.CreateOfficerData;
using OperationAPI.Application.Features.OfficerData.Command.UpdateOfficerData;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightOfficerController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlightOfficerController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpPost("")]
        public async Task<IActionResult> Post(OfficerDataDomain model)
        {
            var data = await mediator.Send(new CreateOfficerDataCommand(model));

            return Ok(data);
        }


        //[HttpPut("")]
        //public async Task<IActionResult> Put(OfficerDataDomain model)
        //{
        //    var data = await mediator.Send(new UpdateOfficerDataCommand(model));

        //    return Ok(data);
        //}


        [HttpPut("")]
        public async Task<IActionResult> Put([FromBody] OfficerDataDomain model)
        {
            var data = await mediator.Send(new UpdateOfficerDataCommand(model));
            return Ok(data);
        }





    }
}
