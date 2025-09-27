using AutoMapper;
using AutoMapper.Execution;
using Microsoft.Extensions.Configuration;
using Mo_Talabat_Core_Domain.Common.Dtos;
using Mo_Talabat_Core_Domain.Entity.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.Mapping
{
    internal class PictureResolver(IConfiguration configuration) : IValueResolver<Product, ProductReturnDto, string>
    {
        public string Resolve(Product source, ProductReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
               return $"{configuration["Urls:ApisBaseUrl"]}{source.PictureUrl}";
            }
            return String.Empty;
        }
    }
}
