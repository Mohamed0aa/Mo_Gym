using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Specifications
{
    public class BaseSpecification<TEntity, TKey> : ISpecification<TEntity, TKey>
        where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public Expression<Func<TEntity, bool>> Criteria { get; set; } = null!;
        public List<Expression<Func<TEntity, object>>> Includes { get; set; } = [];
        public Expression<Func<TEntity, object>>? OrderBy {  get; set; } = null;
        public Expression<Func<TEntity, object>>? OrderByDesc { get; set; } = null;
        public int Skip { get ; set; }
        public int Take { get ; set; }
        public bool IsPaginated { get ; set ; }

        public BaseSpecification(Expression<Func<TEntity, bool>> _Criteria)
        {
            Criteria= _Criteria;
        }
        public BaseSpecification(int id)
        {
            Criteria=E=>E.Id.Equals(id);

        }
    }
}
