using Mo_Talabat_Core_Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Contract
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        IGenericRepo<TEntity, TKey> GetRepo<TEntity, TKey>() 
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>;

        Task<int> CompleteAsync();
     
    }
}
