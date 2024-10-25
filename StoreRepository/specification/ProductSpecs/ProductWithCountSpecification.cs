using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.specification.ProductSpecs
{
    public class ProductWithCountSpecification : BaseSpecification<Product>
    {
        public ProductWithCountSpecification(ProductSpecification specs)
            : base(Product => (!specs.BrandId.HasValue || Product.BrandId == specs.BrandId.Value) &&
                              (!specs.TypeId.HasValue || Product.TypeId == specs.TypeId.Value) &&
              (string.IsNullOrEmpty(specs.Search) || Product.Name.Trim().ToLower().Contains(specs.Search))
            )
        {
        
        
        }   
                            

           
    }
}
