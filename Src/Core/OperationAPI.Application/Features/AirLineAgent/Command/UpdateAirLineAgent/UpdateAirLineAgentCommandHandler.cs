using MediatR;
using OperationAPI.Application.Contracts.Identity;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AirLineAgent.Command.CreateAirLineAgent;
using OperationAPI.Application.Models.IdentityModel;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.AirLineAgent.Command.UpdateAirLineAgent
{
   


    public class UpdateAirLineAgentCommandHandler : IRequestHandler<UpdateAirLineAgentCommand, AirLineAgentDomain>
    {
        private readonly IAirlineAgentService service;
        private readonly IUnitOfWork unitOfWork;
        private readonly IAuthService authService;

        public UpdateAirLineAgentCommandHandler(IAirlineAgentService service, IUnitOfWork unitOfWork, IAuthService authService)
        {
            this.service = service;
            this.unitOfWork = unitOfWork;
            this.authService = authService;
        }

        public async Task<AirLineAgentDomain> Handle(UpdateAirLineAgentCommand command, CancellationToken cancellationToken)
        {
            // validation
            var validator = new UpdateAirLineAgentValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(AirLineAgentDomain), validationResult.Errors);
            }

            await unitOfWork.BeginTransactionAsync();

            try
            {
                var editUser = new EditUserRequest
                {
                    Id = command.model.UserId,
                    FullName = command.model.NameAn,
                    Email = command.model.Email,
                    //Password = "Asd@12345",
                    PhoneNumber = command.model.Phone1,
                    UserName = command.model.NameAn,
                    UserRoles = new List<string> { "Agent" }
                   
                   
                };

                var registerationResult = await authService.Edit(editUser);
                //command.model.UserId = registerationResult.UserId;
                var createAirlineAgentResult = await service.UpdateAsync(command.model);


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
