using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OperationAPI.Application.Contracts.Services;
using OperationAPI.Domain.Common;
using OperationAPI.Presistence.PartialModel;
using OperationAPI.Presistence.Models;
namespace OperationAPI.Presistence.Repositories
{
   public class GenericRepository<XDomain, XEntity> : IGenericService<XDomain> where XDomain : BaseDomain where XEntity : class, IBaseEntity
    {

        public Entities Context { get; }
        public IMapper Mapper { get; }

        public GenericRepository(Entities context, IMapper mapper)
        {
            this.Context = context;
            this.Mapper = mapper;
        }
        public async Task<XDomain> CreateAsync(XDomain model)
        {
            try
            {
                var entity = this.Mapper.Map<XEntity>(model);
                await Context.Set<XEntity>().AddAsync(entity);

                await Context.SaveChangesAsync();

                model.Id = entity.Id;
                return model;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public virtual async Task<List<XDomain>> GetAsync()
        {
            var query = this.Context.Set<XEntity>().AsQueryable();
            var entityType = this.Context.Model.FindEntityType(typeof(XEntity));

            if (entityType != null)
            {
                var navigationProperties = entityType.GetNavigations().Select(e => e.Name);
                foreach (var property in navigationProperties)
                {

                    query = query.Include(property);

                }
            }

            // تنفيذ الاستعلام بشكل غير متزامن
            var data = await query.ToListAsync();

            // تحويل البيانات إلى النوع المطلوب باستخدام AutoMapper
            return this.Mapper.Map<List<XDomain>>(data);
        }

        public virtual async Task<XDomain> GetByIdAsync(int id, bool withTracking = false)
        {
            var query = Context.Set<XEntity>().AsQueryable();

            // الحصول على نوع الكائن من السياق
            var entityType = Context.Model.FindEntityType(typeof(XEntity));

            if (entityType != null)
            {
                // الحصول على جميع الخصائص الملاحظة (navigation properties)
                var navigationProperties = entityType.GetNavigations().Select(e => e.Name);
                foreach (var property in navigationProperties)
                {
                    query = query.Include(property);
                }
            }

            // استخدام FirstOrDefaultAsync لجلب الكائن باستخدام الـ id
            var res = withTracking ? await query.FirstOrDefaultAsync(q => q.Id == id)
                : await query.AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);

            // تحويل الكائن إلى النوع المستهدف باستخدام AutoMapper
            return Mapper.Map<XDomain>(res);
        }

        public async Task<XDomain> UpdateAsync(XDomain model)
        {
            try
            {
                var entity = Mapper.Map<XEntity>(model);
                Context.Entry(entity).State = EntityState.Modified;
                await Context.SaveChangesAsync();

                return model;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteAsync(XDomain entity)
        {
            try
            {
                var entityToDelete = await Context.Set<XEntity>().FindAsync(entity.Id);
                // var entityToDelete = this.mapper.Map<TEntity>(entity);

                Context.Remove<XEntity>(entityToDelete!);
                await Context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

   }
}
