using Microsoft.EntityFrameworkCore;
using Mo_Talabat_Core_Domain.Common;
using Mo_Talabat_Core_Domain.Contract;
using Mo_Talabat_Core_Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Infrastructure_presistence.Repositories
{
    public static class SpecificationsEvaluator<TEntity,TKey>where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public static IQueryable<TEntity>GetQuary(IQueryable<TEntity>inputQuery,ISpecification<TEntity,TKey> Spec)
        {
            var query = inputQuery;
            if(Spec.Criteria is not null) 
                query=query.Where(Spec.Criteria);

            //sort
            if(Spec.OrderBy is not null)
                query = query.OrderBy(Spec.OrderBy);
            else if(Spec.OrderByDesc is not null)
                query=query.OrderByDescending(Spec.OrderByDesc);

            //pagination
            if(Spec.IsPaginated)
                query = query.Skip(Spec.Skip).Take(Spec.Take);

            //includes
            query=Spec.Includes.Aggregate(query,(curr,includeExpression)
                    =>curr.Include(includeExpression));

            return query;
        }
    }
}
