﻿using StoreData.Contexts;
using StoreData.Entities;
using StoreRepository.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _context;
        private Hashtable _repositories;

        public UnitOfWork(StoreDbContext context) 
        {
            _context = context;
        }
        public async Task<int> CompleteAsync()
            => await _context.SaveChangesAsync();
       
        public IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            if( _repositories is null )
                _repositories = new Hashtable();

            var entityKey = typeof(TEntity).Name; // "Product"


            if (!_repositories.ContainsKey( entityKey ) )
            {
                var repositoryType = typeof(GenericRepository<,>); // "GenericRepository<Product., int>"

                var repositoryInstance = Activator.CreateInstance( repositoryType.MakeGenericType(typeof(TEntity), typeof(TKey)) , _context);

                _repositories.Add(entityKey, repositoryInstance);
            }

            return (IGenericRepository<TEntity, TKey>) _repositories[entityKey];

        }
    }
}
