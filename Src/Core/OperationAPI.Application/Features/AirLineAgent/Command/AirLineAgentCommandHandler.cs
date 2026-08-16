using MediatR;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.CreateAircraftRegistration;
using OperationAPI.Application.Models.IdentityModel;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command
{
   public class AirLineAgentCommandHandler : IRequestHandler<AirLineAgentCommand, AirLineAgentDomain>
    {
        private readonly IAirlineAgentService service;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;

        public AirLineAgentCommandHandler(IAirlineAgentService service, IUnitOfWork unitOfWork, IAuthService authService)
        {
            this.service = service;
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public async Task<AirLineAgentDomain> Handle(AirLineAgentCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new AirlineAgentValidator(service);
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
                    UserName = command.model.NameAr,
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
