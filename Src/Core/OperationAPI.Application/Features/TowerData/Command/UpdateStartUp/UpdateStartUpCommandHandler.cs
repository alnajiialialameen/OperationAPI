using AutoMapper;
using MediatR;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Application.Exceptions;
using OperationAPI.Application.Features.AircraftRegisteration.Command.UpdateAircraftRegistration;
using OperationAPI.Application.Features.TowerData.Command.CreateTowerData;
using OperationAPI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Application.Features.TowerData.Command.UpdateTowerData
{
   




    public class UpdateStartUpCommandHandler : IRequestHandler<UpdateStartUpCommand, TowerDataDomain>
    {
        private readonly ITowerDataService service;
        private readonly IMapper mapper;
        public UpdateStartUpCommandHandler(ITowerDataService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<TowerDataDomain> Handle(UpdateStartUpCommand command, CancellationToken cancellationToken)
        {
            var validator = new UpdateStartUpValidator(service);
            var validationResult = await validator.ValidateAsync(command);

            if (validationResult.Errors.Any())
            {
                throw new BadRequestException(nameof(InitialDataDomain), validationResult.Errors);
            }

            // 1. جلب السجل الموجود في قاعدة البيانات للتأكد من وجوده
            var towerData = await service.GetByIdAsync(command.model.Id);

            if (towerData == null)
            {
                throw new NotFoundException(nameof(TowerDataDomain), command.model.Id);
            }

            // 2. تحديث الحقول باستخدام AutoMapper
            mapper.Map(command.model, towerData);
            towerData.CompanyInfoId = 10;
            towerData.Date = DateOnly.FromDateTime(DateTime.Now);

            // 3. حفظ التعديل
            return await service.UpdateAsync(towerData);
        }
    }







}
