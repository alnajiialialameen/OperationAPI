using AutoMapper;
using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.TowerData.Command.CreateTowerData;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command
{
   
    public class CreateStartUpCommandHandler : IRequestHandler<CreateStartUpCommand, TowerDataDomain>
    {
        private readonly ITowerDataService service;
        public IMapper Mapper { get; }
        public CreateStartUpCommandHandler(ITowerDataService service, IMapper Mapper)
        {
            this.service = service;
            this.Mapper = Mapper;   
        }

        public async Task<TowerDataDomain> Handle(CreateStartUpCommand command, CancellationToken cancellationToken)
        {
            //command.model.CompanyInfoId = 10;
            //command.model.Date = DateOnly.FromDateTime(DateTime.Now);
            var validator = new CreateStartUpValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {

                throw new BadRequestException(nameof(InitialDataDomain), validationResult.Errors);
            }

            var towerData = new TowerDataDomain();
        
            Mapper.Map(command.model, towerData);
            towerData.CompanyInfoId = 10;
            towerData.Date = DateOnly.FromDateTime(DateTime.Now);


            var res = await service.CreateAsync(towerData);
            return res;

        }
    }



}
