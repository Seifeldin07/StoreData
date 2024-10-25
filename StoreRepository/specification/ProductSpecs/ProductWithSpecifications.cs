using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.specification.ProductSpecs
{
    public class ProductWithSpecifications : BaseSpecification<Product>
    {
        public ProductWithSpecifications(ProductSpecification specs)
            : base(Product => (!specs.BrandId.HasValue || Product.BrandId == specs.BrandId.Value) &&
                              (!specs.TypeId.HasValue || Product.TypeId == specs.TypeId.Value)&&
                       (string.IsNullOrEmpty(specs.Search) || Product.Name.Trim().ToLower().Contains(specs.Search)))



        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);
            AddOrderBy(x => x.Name);

            ApplyPagination(specs.PageSize * (specs.PageIndex - 1), specs.PageSize);

            if (!string.IsNullOrEmpty(specs.sort))
            {
                switch (specs.sort)
                {
                    case "priceASC": AddOrderBy(X => X.ProductPrice); break;

                    case "price DESC": 
                        AddOrderBy(x=>x.ProductPrice); break;

                    default:
                        AddOrderBy(x => x.Name);
                        break;
                         


                }
            }

        }
        public ProductWithSpecifications(int? id) :
           base(product => product.Id == id)
        {
            AddInclude(x => x.Brand);
            AddInclude(x => x.Type);

        }
    }
}
