using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Infrastructure_presistence.Data;
using Mo_Talabat_Infrastructure_presistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.UnitOfWork
{
    public class UnitOfWork(StoreContext dbContext) : IUnitOfWork
    {
        private readonly ConcurrentDictionary<string, object> repos= new ();
        public async Task<int> CompleteAsync()=> await dbContext.SaveChangesAsync();
        

        public async ValueTask DisposeAsync()=>await dbContext.DisposeAsync();
        

        public IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
            where TKey : IEquatable<TKey>
        {
            return (IGenericRepo<TEntity, TKey>) repos.GetOrAdd(typeof(TEntity).Name, new GenericRepo<TEntity, TKey>(dbContext));
        }
    }
}
