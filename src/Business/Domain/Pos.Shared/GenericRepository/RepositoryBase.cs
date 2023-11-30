﻿using AutoMapper;
using HRMaster.SharedKernel.Extensions.Pagging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared.GenericRepository
{
    public  abstract class RepositoryBase<TEntity, IModel, T> : IRepository<TEntity, IModel, T>
    where TEntity : class, IEntity
    where IModel : class, IVm
    where T : IEquatable<T>                        

    {
        private readonly IMapper _mapper;
        private readonly DbContext _dbContext;

     

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();
        public RepositoryBase(IMapper mapper, DbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }
        public async Task<IModel> Add(TEntity entity)
        {
            
            DbSet.Add(entity);           
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(entity);
        }

        public async Task Delete(T id)
        {
            var entity = await DbSet.FindAsync(id);
            if(entity==null)
            {
                throw new Exception("Id Not Match");
            }
            _dbContext.Remove(entity);
            _dbContext.SaveChangesAsync();
        }

        public async Task<IModel> GetById(T id)
        {
            var entity = await DbSet.FindAsync(id);
            return _mapper.Map<IModel>(entity);
        }
        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate)
        {
            var data = await DbSet.Where(predicate).OrderByDescending(e => e.Id).PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }

        public async Task<IEnumerable<IModel>> GetList()
        {
            var entityList = DbSet.AsAsyncEnumerable();
            return _mapper.Map<IEnumerable<IModel>>(entityList);
        }
        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var data = await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include)))
                .PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }

        public async Task<Paging<IModel>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {

            var data = await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include), c => c.Where(predicate)))
                .PagingAsync(pageIndex, pageSize);
            return data.ToPagingModel<TEntity, IModel>(_mapper);
        }
        public async Task<Paging<TResult>> GetPageAsync<TResult>(int pageIndex, int pageSize, Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            return await orderBy(includes.Aggregate(DbSet.AsQueryable(),
                (current, include) => current.Include(include), c => c.Where(predicate)))
                .PagingAsync(selector, pageIndex, pageSize);

        }

        public async Task<IModel> Update(T id, TEntity entity)
        {
            
            if (id.Equals(entity.Id))
            {
                throw new Exception("Id Not Match");
            }
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChangesAsync();
            return _mapper.Map<IModel>(entity);
        }
    }
}
