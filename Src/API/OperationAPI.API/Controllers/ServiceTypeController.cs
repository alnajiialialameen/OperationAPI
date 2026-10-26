using MediatR;
using Microsoft.AspNetCore.Mvc;
using OperationAPI.Application.Features.ServiceType.Quieres.GetAllServiceType;

namespace OperationAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypeController : ControllerBase
    {
        private readonly IMediator mediator;

        public ServiceTypeController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await mediator.Send(new GetAllServiceTypeRequest());

            return Ok(data);
        }
    }
}
