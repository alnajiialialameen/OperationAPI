using MediatR;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Models.IdentityModel;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.AirLineAgent.Command.CreateAirLineAgent
{
   public class CreateAirLineAgentCommandHandler : IRequestHandler<CreateAirLineAgentCommand, AirLineAgentDomain>
    {
        private readonly IAirlineAgentService service;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;

        public CreateAirLineAgentCommandHandler(IAirlineAgentService service, IUnitOfWork unitOfWork, IAuthService authService)
        {
            this.service = service;
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public async Task<AirLineAgentDomain> Handle(CreateAirLineAgentCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new CreateAirlineAgentValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AircraftRegistrationDomain), validationResult.Errors);
            }

            await unitOfWork.BeginTransactionAsync();
            
            try
            { 
                var registeration = new RegisterationRequest
                {
                    FullName = command.model.NameAn,
                    Email = command.model.Email,
                    Password = "Asd@12345",
                    PhoneNumber = command.model.Phone1,
                    UserName = command.model.NameAn,
                    UserRoles = new List<string> { "Agent" }
                };
               
                var registerationResult = await authService.Register(registeration);
                command.model.UserId = registerationResult.UserId;
                var createAirlineAgentResult = await service.CreateAsync(command.model);
               

                await unitOfWork.CommitAsync();
                return createAirlineAgentResult;

            }
            catch (Exception ex)
            {
                await unitOfWork.RollbackAsync();
                throw;
            }


        }
    }
}
