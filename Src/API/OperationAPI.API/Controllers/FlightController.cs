using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.TowerData.Command.CreateDepartureInitial;
using OperationAPI.Application.Features.TowerData.Command.CreateDepartureService;
using OperationAPI.Application.Features.TowerData.Command.CreateLandingService;
using OperationAPI.Application.Features.TowerData.Command.CreateTowerData;
using OperationAPI.Application.Features.TowerData.Command.DeleteTowerData;
using OperationAPI.Application.Features.TowerData.Command.UpdateTowerData;
using OperationAPI.Application.Features.TowerData.Quieres.GetAllTowerData;
using OperationAPI.Application.Features.TowerData.Quieres.GetTowerDataById;
using OperationAPI.Domain;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator mediator;

        public FlightController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var data = await mediator.Send(new GetAllTowerDataRequest());

        //    return Ok(data);
        //}

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await mediator.Send(new GetTowerDataByIdRequest(id));

            return Ok(data);
        }

        [HttpPost("StartUP")]
        public async Task<IActionResult> Post([FromBody] InitialDataDomain model)
        {
            var data = await mediator.Send(new CreateStartUpCommand(model));

            return Ok(data);
        }

        //[HttpPut("StartUP")]
        //public async Task<IActionResult> Put([FromBody] TowerDataDomain model)
        //{
        //    var data = await mediator.Send(new UpdateStartUpCommand(model));

        //    return Ok(data);
        //}


        [HttpPut("DepartureFlight")]
        public async Task<IActionResult> InitialDeparture([FromBody] DepartureInitialDomain model)
        {
            var data = await mediator.Send(new UpdateDepartureFlightCommand(model));
            return Ok(data);
        }


        [HttpPost("DepartureService")]
        public async Task<IActionResult> DepartureService([FromBody] DepartureServiceDomain model)
        {
            var data = await mediator.Send(new CreateDepartureServiceCommand(model));
            return Ok(data);
        }


        [HttpPost("LandingService")]
        public async Task<IActionResult> LandingService([FromBody] LandingServiceDomain model)
        {
            var data = await mediator.Send(new CreateLandingServiceCommand(model));
            return Ok(data);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await mediator.Send(new DeleteTowerDataCommand(id));

            return Ok(data);
        }
    }
}
