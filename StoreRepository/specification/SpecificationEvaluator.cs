using Microsoft.EntityFrameworkCore;
using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.specification
{
    public class SpecificationEvaluator<TEnity,Tkey > where TEnity : BaseEntity<Tkey>
    {
        public static IQueryable<TEnity> GetQuery(IQueryable<TEnity> inPutQuery, ISpecification<TEnity> specs)
        {
            var query = inPutQuery;

            if (specs.Criteria is not null)
                query = query.Where(specs.Criteria);

            if (specs.OrderBy != null)
                query = query.OrderBy(specs.OrderBy);

            if (specs.OrderByDescending != null)
                query = query.OrderByDescending(specs.OrderByDescending);
           
            if (specs.IsPaginated)
                query = query.Skip(specs.Skip).Take(specs.Take);

            query = specs.Includes.Aggregate(query,(current,incluedExpression)=>current.Include(incluedExpression));
            return query; 
        }
    }
}
