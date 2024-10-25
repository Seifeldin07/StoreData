﻿using StoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreRepository.Interfaces
{
    public interface IUnitOfWork
    {
        IGenericRepository<TEntity, TKey> Repository<TEntity, TKey>() where TEntity : BaseEntity<TKey>;
        Task<int> CompleteAsync();

    }
}
