using AutoMapper;
using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Domain;

namespace OperationAPI.Application.Features.TowerData.Command.CreateLandingService
{
  
    public class CreateLandingServiceCommandHandler : IRequestHandler<CreateLandingServiceCommand, OfficerDataDomain>
    {

        readonly IOfficerDataService service;
        public IMapper Mapper { get; }
        readonly ITowerDataService Tservice;
        public CreateLandingServiceCommandHandler(IOfficerDataService service, IMapper mapper, ITowerDataService tservice   )
        {
            this.service = service;
            this.Mapper = mapper;
            Tservice = tservice;
        }
        public async Task<OfficerDataDomain> Handle(CreateLandingServiceCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateLandingServiceValidator(service);
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
                    throw new NotFoundException(nameof(LandingServiceDomain), command.model.Id);
                }
              

                Mapper.Map(command.model, officerData);
                var result = service.UpdateAsync(officerData);
                var result2 = Tservice.setStatus(command.model.TowerDataId, 5);
                return await result;
            }
            else
            {
                OfficerDataDomain officerData = new OfficerDataDomain();

                Mapper.Map(command.model, officerData);
                var res = await service.CreateAsync(officerData);
                var result2 = Tservice.setStatus(command.model.TowerDataId, 5);
                return res;
            }
        }

    }









}
