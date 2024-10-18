using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Interfaces
{
    public interface IGenericRepository <TEntity , TKey> where TEntity : BaseEntity <TKey>
    {
        Task <TEntity> GetByIdAsync (TKey id);

        Task<IReadOnlyList<TEntity>> GetAllAsync ();

        Task AddAsync(TEntity entity);

        Task Update(TEntity entity);

        Task Delete(TEntity entity);
    }
} 
