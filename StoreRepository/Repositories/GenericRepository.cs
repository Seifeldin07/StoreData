using Microsoft.EntityFrameworkCore;
using StoreData.Contexts;
using StoreData.Entities;
using StoreRepository.Interfaces;
using StoreRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>

    {
        private readonly StoreDbContext _context;

        public GenericRepository (StoreDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(TEntity entity)
        
            => await _context.Set<TEntity>().AddAsync(entity);

        public async void Delete(TEntity entity)

           => _context.Set<TEntity>().Remove(entity);

        public async Task<IReadOnlyList<TEntity>> GetAllAsNOTrackingAsync()
            => await _context.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        
            => await _context.Set<TEntity>().ToListAsync();

        //public async Task<TEntity> GetByIdAsNOTrackingAsync(TKey id)
        //=> await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.id == id);

        public async Task<TEntity> GetByIdAsync(TKey id)
          
            => await _context.Set<TEntity>().FindAsync(id);
        
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        Task IGenericRepository<TEntity, TKey>.Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        Task IGenericRepository<TEntity, TKey>.Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

    }
}






