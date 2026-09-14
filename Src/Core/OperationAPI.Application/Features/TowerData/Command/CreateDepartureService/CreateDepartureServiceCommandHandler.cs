using AutoMapper;
using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;


namespace OperationAPI.Application.Features.TowerData.Command.CreateDepartureService
{


    public class CreateDepartureServiceCommandHandler : IRequestHandler<CreateDepartureServiceCommand, OfficerDataDomain>
    {

        readonly IOfficerDataService service;
        public IMapper Mapper { get; }

        public CreateDepartureServiceCommandHandler(IOfficerDataService service, IMapper mapper)
        {
            this.service = service;
            this.Mapper = mapper;
        }
        public async Task<OfficerDataDomain> Handle(CreateDepartureServiceCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateDepartureServiceValidator(service);
            var validationResult = await validator.ValidateAsync(command);
            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(DepartureInitialDomain), validationResult.Errors);
            }

            if (command.model.Id > 0)
            {
                var officerData = await service.GetByIdAsync(command.model.Id);

                if (officerData == null)
                {
                    throw new NotFoundException(nameof(DepartureServiceDomain), command.model.Id);
                }

              
                Mapper.Map(command.model, officerData);
                return await service.UpdateAsync(officerData);
            }
            else
            {
                OfficerDataDomain officerData = new OfficerDataDomain();
            
                Mapper.Map(command.model, officerData);
                var res = await service.CreateAsync(officerData);
                return res;
            }
        }

    }
}
