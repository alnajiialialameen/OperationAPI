using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationAPI.Presistence.Repositories
{
  public class ServiceRequestDetailRepository : GenericRepository<ServiceRequestDetailDomain, ServiceRequestDetail>, IServiceRequestDetailService
    {
        public ServiceRequestDetailRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        //public async Task<ServiceRequestDetailDomain> CreatelService(ServiceRequestDetailDomain model)
        //{
        //    if (model == null)
        //        throw new ArgumentNullException(nameof(model));

        //    using var transaction = await Context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        var masterEntity = Mapper.Map<ServiceRequest>(model);

        //        await Context.ServiceRequests.AddAsync(masterEntity);
        //        await Context.SaveChangesAsync(); // هنا يتم توليد الـ Id الخاص بـ ServiceRequest

        //        var detailEntity = Mapper.Map<ServiceRequestDetail>(model);

        //        detailEntity.ServiceRequestId = masterEntity.Id; // ربط المفتاح الأجنبي
        //        detailEntity.RequestedAt ??= DateTime.UtcNow;    // تعيين التاريخ الحالي إذا كان فارغاً

        //        await Context.ServiceRequestDetails.AddAsync(detailEntity);
        //        await Context.SaveChangesAsync();

        //        await transaction.CommitAsync();

        //        model.Id = detailEntity.Id;
        //        //model.ServiceRequestId = masterEntity.Id;

        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        await transaction.RollbackAsync();
        //        throw;
        //    }
        //}



        public async Task<ServiceRequestDetailDomain> CreatelService(ServiceRequestDetailDomain model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
           
            if (model.AirlineId == null || model.AirlineId == 0) 
            {
                var towerData = await Context.TowerData.FirstOrDefaultAsync(td => td.Id == model.TowerDataId);
                model.AirlineId = towerData?.AirLineId;
            }


            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                // 1. تعبئة جدول الأب يدوياً بدون AutoMapper
                var masterEntity = new ServiceRequest
                {
                    TowerDataId = model.TowerDataId,
                    AirlineId = model.AirlineId
                };

                await Context.ServiceRequests.AddAsync(masterEntity);
                await Context.SaveChangesAsync(); // هنا يتم توليد الـ Id الخاص بـ ServiceRequest

                // 2. استخدام AutoMapper لجدول التفاصيل فقط
                var detailEntity = Mapper.Map<ServiceRequestDetail>(model);

                detailEntity.ServiceRequestId = masterEntity.Id; // ربط المفتاح الأجنبي
                detailEntity.RequestedAt ??= DateTime.UtcNow;    // تعيين التاريخ الحالي إذا كان فارغاً
                detailEntity.RequestStatus = 1;


                await Context.ServiceRequestDetails.AddAsync(detailEntity);
                await Context.SaveChangesAsync();

                await transaction.CommitAsync();

                model.Id = detailEntity.Id;
                //model.ServiceRequestId = masterEntity.Id;

                return model;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<ServiceRequestDetailViewDomain>> GetIServiceRequestDetailServiceByTowerId(int? TowerId)
        {
            if (!TowerId.HasValue)
                return new List<ServiceRequestDetailViewDomain>();

            return await Context.ServiceRequestDetails
                .AsNoTracking()
                .Where(x => x.ServiceRequest.TowerDataId == TowerId.Value)
                .ProjectTo<ServiceRequestDetailViewDomain>(Mapper.ConfigurationProvider)
                .ToListAsync();
        }







        //public async Task<ServiceRequestDetailDomain> UpdateService(ServiceRequestDetailDomain model)
        //{
        //    if (model == null)
        //        throw new ArgumentNullException(nameof(model));

        //    using var transaction = await Context.Database.BeginTransactionAsync();
        //    try
        //    {
        //        // 1. جلب سجل التفاصيل (Detail) من قاعدة البيانات للتأكد من وجوده
        //        var detailEntity = await Context.ServiceRequestDetails.FirstOrDefaultAsync(x => x.Id == model.Id);

        //        if (detailEntity == null)
        //            throw new KeyNotFoundException($"ServiceRequestDetail with Id {model.Id} was not found.");

        //        // 2. تحديث الجدول الأول (Master - ServiceRequest) إذا كان مرتبطاً
        //        var serviceRequestId = detailEntity.ServiceRequestId;
        //        if (serviceRequestId.HasValue)
        //        {
        //            var masterEntity = await Context.ServiceRequests
        //                .FirstOrDefaultAsync(x => x.Id == serviceRequestId.Value);

        //            if (masterEntity != null)
        //            {
        //                // يقوم AutoMapper بتحديث خصائص الكائن الموجود مباشرة (OfficerDataId, AirlineId)
        //                Mapper.Map(model, masterEntity);

        //                Context.ServiceRequests.Update(masterEntity);
        //                await Context.SaveChangesAsync();
        //            }
        //        }

        //        // الاحتفاظ بقيمة المفتاح الأجنبي وتاريخ الطلب الأصلي قبل عمل Map
        //        var originalRequestId = detailEntity.ServiceRequestId;
        //        var originalRequestedAt = detailEntity.RequestedAt;

        //        // 3. تحديث الجدول الثاني (Detail - ServiceRequestDetail)
        //        Mapper.Map(model, detailEntity);

        //        // ضمان عدم ضياع الربط أو التاريخ الأصلي في حال جاءت فارغة في الـ model
        //        detailEntity.ServiceRequestId = originalRequestId;
        //        detailEntity.RequestedAt = model.RequestedAt ?? originalRequestedAt;

        //        Context.ServiceRequestDetails.Update(detailEntity);
        //        await Context.SaveChangesAsync();

        //        // 4. اعتماد التعديلات في قاعدة البيانات
        //        await transaction.CommitAsync();

        //        //model.ServiceRequestId = detailEntity.ServiceRequestId;
        //        return model;
        //    }
        //    catch (Exception)
        //    {
        //        await transaction.RollbackAsync();
        //        throw;
        //    }
        //}
        public async Task<ServiceRequestDetailDomain> UpdateService(ServiceRequestDetailDomain model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));
            if (model.AirlineId == null || model.AirlineId == 0)
            {
                var towerData = await Context.TowerData.FirstOrDefaultAsync(td => td.Id == model.TowerDataId);
                model.AirlineId = towerData?.AirLineId;
            }
            using var transaction = await Context.Database.BeginTransactionAsync();
            try
            {
                // 1. جلب سجل التفاصيل (Detail) من قاعدة البيانات للتأكد من وجوده
                var detailEntity = await Context.ServiceRequestDetails.FirstOrDefaultAsync(x => x.ServiceRequestId == model.Id);

                if (detailEntity == null)
                    throw new KeyNotFoundException($"ServiceRequestDetail with Id {model.Id} was not found.");

                // 2. تحديث الجدول الأول (Master - ServiceRequest) يدوياً بدون AutoMapper
                var serviceRequestId = detailEntity.ServiceRequestId;
                if (serviceRequestId.HasValue)
                {
                    var masterEntity = await Context.ServiceRequests
                        .FirstOrDefaultAsync(x => x.Id == serviceRequestId.Value);

                    if (masterEntity != null)
                    {
                        // تحديث الحقلين يدوياً
                        masterEntity.TowerDataId = model.TowerDataId;
                        masterEntity.AirlineId = model.AirlineId;

                        Context.ServiceRequests.Update(masterEntity);
                        await Context.SaveChangesAsync();
                    }
                }

                // الاحتفاظ بقيمة المفتاح الأجنبي وتاريخ الطلب الأصلي قبل عمل Map
                var originalRequestId = detailEntity.ServiceRequestId;
                var originalRequestedAt = detailEntity.RequestedAt;

                // 3. تحديث الجدول الثاني (Detail - ServiceRequestDetail) باستخدام AutoMapper
                Mapper.Map(model, detailEntity);

                // ضمان عدم ضياع الربط أو التاريخ الأصلي في حال جاءت فارغة في الـ model
                detailEntity.ServiceRequestId = originalRequestId;
                detailEntity.RequestedAt = model.RequestedAt ?? originalRequestedAt;


                // تغيير RequestStatus تلقائياً بناءً على المرحلة الحالية (أو الاعتماد على القيمة القادمة من الـ model)
                if (!string.IsNullOrEmpty(detailEntity.ConfirmAgentBy))
                {
                    detailEntity.RequestStatus = 3;
                }
                else if (!string.IsNullOrEmpty(detailEntity.AcceptedBy))
                {
                    detailEntity.RequestStatus = 2;
                }
                else if (!string.IsNullOrEmpty(detailEntity.RequestedBy))
                {
                    detailEntity.RequestStatus = 1;
                }


                Context.ServiceRequestDetails.Update(detailEntity);
                await Context.SaveChangesAsync();

                // 4. اعتماد التعديلات في قاعدة البيانات
                await transaction.CommitAsync();

                //model.ServiceRequestId = detailEntity.ServiceRequestId;
                return model;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }





        public async Task<ServiceRequestDetailDomain> AcceptOfficer(confirmServiceDetailDomain model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var detailEntity = await Context.ServiceRequestDetails.Include(x => x.ServiceRequest).FirstOrDefaultAsync(x => x.Id == model.Id);

            if (detailEntity == null)
                throw new KeyNotFoundException($"ServiceRequestDetail with Id {model.Id} was not found.");

            // تحديث حقول القبول فقط
            detailEntity.AcceptedAt = model.At ?? DateTime.UtcNow;
            detailEntity.AcceptedBy = model.By;
            detailEntity.RequestStatus = 2; // 2 = تم القبول من الضابط

            Context.ServiceRequestDetails.Update(detailEntity);
            await Context.SaveChangesAsync();

            // تحويل الكيان المحدث إلى Domain وإرجاعه
            return Mapper.Map<ServiceRequestDetailDomain>(detailEntity);
        }

        public async Task<ServiceRequestDetailDomain> ConfirmAgent(confirmServiceDetailDomain model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            var detailEntity = await Context.ServiceRequestDetails.Include(x => x.ServiceRequest).FirstOrDefaultAsync(x => x.Id == model.Id);

            if (detailEntity == null)
                throw new KeyNotFoundException($"ServiceRequestDetail with Id {model.Id} was not found.");

            // تحديث حقول تأكيد الوكيل فقط
            detailEntity.ConfirmAgentAt = model.At ?? DateTime.UtcNow;
            detailEntity.ConfirmAgentBy = model.By;
            detailEntity.RequestStatus = 3; // 3 = تم التأكيد من الوكيل

            Context.ServiceRequestDetails.Update(detailEntity);
            await Context.SaveChangesAsync();

            // تحويل الكيان المحدث إلى Domain وإرجاعه
            return Mapper.Map<ServiceRequestDetailDomain>(detailEntity);
        }









    }
}
