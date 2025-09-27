using Microsoft.EntityFrameworkCore;
using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Infrastructure_presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Repositories
{
    internal class GenericRepo<TEntity, TKey>(StoreContext dbContext) : IGenericRepo<TEntity, TKey> 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool WithTraking = false)
            => WithTraking? await dbContext.Set<TEntity>().ToListAsync()
            : await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity,TKey>spec,bool WithTraking = false)
        {
            return await ApplyQuery(spec).ToListAsync();
        }
        public async Task<TEntity?> GetAsync(TKey id)
            => await dbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetAsync(ISpecification<TEntity, TKey> spec)
        {
            
            return await ApplyQuery(spec).FirstOrDefaultAsync();
        }
        public async Task AddAsync(TEntity entity)
        => await dbContext.Set<TEntity>().AddAsync(entity);

        public void UpdateA(TEntity entity)
        =>dbContext.Set<TEntity>().Update(entity);

        public void Delete(TEntity entity)
            =>dbContext.Set<TEntity>().Remove(entity);


        public IQueryable<TEntity> ApplyQuery(ISpecification<TEntity,TKey> spec)
        {
            return SpecificationsEvaluator<TEntity, TKey>.GetQuary(dbContext.Set<TEntity>(), spec);
        }
    }
}
