using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftSize.Command.UpdateAircraftSize;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.FuelCompany.Command.UpdateFuelCompany
{
  


    public class UpdateFuelCompanyCommandHandler : IRequestHandler<UpdateFuelCompanyCommand, FuelCompanyDomain>
    {
        private readonly IFuelCompanyService service;
        public UpdateFuelCompanyCommandHandler(IFuelCompanyService service)
        {
            this.service = service;
        }

        public async Task<FuelCompanyDomain> Handle(UpdateFuelCompanyCommand command, CancellationToken cancellationToken)
        {
            // validation
            //var validator = new UpdateAircraftSizeValidator(service);
            //var validationResult = await validator.ValidateAsync(command);

            //if (validationResult.Errors.Any())
            //{

            //    throw new BadRequestException(nameof(AircraftSizeDomain), validationResult.Errors);
            //}


            var res = await service.UpdateAsync(command.model);
            return res;
        }
    }











}
