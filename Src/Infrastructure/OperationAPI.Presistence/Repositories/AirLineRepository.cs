using OperationAPI.Presistence.Models;
using OperationAPI.Domain;
using OperationAPI.Application.Contracts.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace OperationAPI.Presistence.Repositories
{
    public class AirLineRepository : GenericRepository<AirLineDomain, AirLine>, IAirlineService
    {
        public AirLineRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        // نفس التحقق في نظام الفيدس هو نفس التحقق هنا في حاله اضافه او تعديل خطوط الطيران
        public async Task<bool> IsUniqueObject(AirLineDomain model)
        {
            return await Context.AirLines
                .AnyAsync(q => q.Id != model.Id && (q.Name == model.NameEn || q.Name == model.NameAr
                                || q.Code == model.Code));
        }
    }
}
