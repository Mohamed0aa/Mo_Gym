using Mo_Talabat_Core_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Contract
{
    public interface IGenericRepo<TEntity, TKey> where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool WithTraking=false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> spec, bool WithTraking = false);
        Task<TEntity?> GetAsync(TKey id);
        Task<TEntity?> GetAsync(ISpecification<TEntity, TKey> spec);
        Task AddAsync(TEntity entity);
        void UpdateA(TEntity entity);
        void Delete(TEntity entity);
    }
}
