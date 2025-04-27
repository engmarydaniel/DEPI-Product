﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null,
            int pageSize = 0, int pageNumber = 1);
        Task<T> GetAsync(Expression<Func<T, bool>> filter = null, string? includeProperties = null);
        Task CreateAsync(T entity);
        Task RemoveAsync(T entity);
        public void Delete(int id);
        public void Insert(T entity);
        public void Update(T entity);
        public T GetById(int id);


    }
}
