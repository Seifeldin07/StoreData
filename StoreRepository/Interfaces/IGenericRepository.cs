using StoreData.Entities;
using StoreRepository.specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Interfaces
{
    public interface IGenericRepository <TEntity , TKey> where TEntity : BaseEntity <TKey>
    {
            //Task <TEntity> GetByIdAsync (TKey id);
            ////Task<TEntity> GetByIdAsNOTrackingAsync(TKey id);
            //Task<IReadOnlyList<TEntity>> GetAllAsync ();

        Task<IReadOnlyList<TEntity>> GetAllAsNOTrackingAsync();

        Task<TEntity> GetWithSpecificationByIdAsync(ISpecification<TEntity> specs);
        
        Task<IReadOnlyList<TEntity>> GetAllWithSpecificationAsync(ISpecification<TEntity> specs);
        Task<int> GetCountSpecificationAsync(ISpecification<TEntity> specs);

        Task AddAsync(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
} 
