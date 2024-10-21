using Microsoft.EntityFrameworkCore;
using StoreData.Contexts;
using StoreData.Entities;
using StoreRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Repositories
{
    public class GenericRepository<TEntity, TKey> /*: IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>*/

    {
    //    private readonly StoreDbContext _Context;

    //    public GenericRepository(StoreDbContext context)
    //    {
    //        _Context = context;
    //    }
    //    public async Task AddAsync(TEntity entity)
    //        => await _Context.Set<TEntity>().AddAsync(entity);



    //    public void Delete(TEntity entity)
    //         => _Context.Set<TEntity>().Remove(entity);


    //    public async Task<IReadOnlyList<TEntity>> GetAllAsync()
    //       => await _Context.Set<TEntity>().ToListAsync();

    //    public async Task<TEntity> GetByIdAsync(TKey id)
    //        => await _Context.Set<TEntity>().FindAsync(id);

    //    public void Update(TEntity entity)
    //        => _Context.Set<TEntity>().Update(entity);

            throw new NotImplementedException();
    }
}
