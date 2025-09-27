using Mo_Talabat_Core_Domain.Entity.Products;
using Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mo_Talabat_Core_Domain.Specifications
{
    public class ProductSpecification:BaseSpecification<Product,int>
    {
        public ProductSpecification(SpecParam specParam):base
        (P
            => (string.IsNullOrEmpty(specParam.Search) || P.Name.ToLower().Contains(specParam.Search)) &&
        (!specParam.BrandId.HasValue ||P.BrandId==specParam.BrandId!.Value)&&
                (!specParam.CategoryId.HasValue || P.CategoryId == specParam.CategoryId!.Value)
        )
        {
            ApplyInclude();
            ApplySort(specParam.Sort);
            ApplyPagination(
                (specParam.PageIndex-1)*specParam.PageSize,specParam.PageSize
                );
        }
        public ProductSpecification(int id) :base(id)
        {
            ApplyInclude();
        }

        private void ApplyInclude()
        {
            Includes.Add(p=>p.Brand!);
            Includes.Add(p=>p.Category!);
        }
        private void ApplyOrderBy(Expression<Func<Product, object>>? Orderexpression)
        {
            OrderBy=Orderexpression;
        }
        private void ApplyOrderByDesc(Expression<Func<Product, object>>?  OrderDescexpression)
        {
            OrderByDesc = OrderDescexpression;
        }
        private void ApplySort(string? sort)
        {
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "nameDesc":
                        ApplyOrderByDesc(p=>p.Name);
                        break;
                    case "priceAsc":
                        ApplyOrderBy(p=>p.Price);
                        break;
                    case "priceDesc":
                        ApplyOrderByDesc(p=>p.Price);
                        break;
                    default: ApplyOrderBy(P=>P.Name);
                        break;
                }
            }
            else
                ApplyOrderBy(p=>p.Name);
        }

        private void ApplyPagination(int skip,int take)
        {
            Skip = skip;
            Take = take;
            IsPaginated = true;
        }


    }
}
