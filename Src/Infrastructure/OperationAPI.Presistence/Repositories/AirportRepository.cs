using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain;
using OperationAPI.Presistence.Models;

namespace OperationAPI.Presistence.Repositories
{
    public class AirportRepository : GenericRepository<AirPortDomain, AirPort>, IAirportService
    {
        public AirportRepository(Entities context, IMapper mapper) : base(context, mapper)
        {
        }

        // نفس التحقق في نظام الفيدس هو نفس التحقق هنا في حاله اضافه او تعديل مطار
        public async Task<bool> IsUniqueObject(AirPortDomain model)
        {
            return await Context.AirPorts
                .AnyAsync(q => q.Id != model.Id && (q.NameEn == model.NameEn || q.NameAr == model.NameAr
                                || q.Code == model.Code));
        }
    }
}
