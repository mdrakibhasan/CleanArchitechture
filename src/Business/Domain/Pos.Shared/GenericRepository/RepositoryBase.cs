using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        }

        public async Task<IModel> GetById(T id)
        {
            var entity = await DbSet.FindAsync(id);
            return _mapper.Map<IModel>(entity);
        }

        public async Task<IEnumerable<IModel>> GetList()
        {
            var entityList = DbSet.AsAsyncEnumerable();
            return _mapper.Map<IEnumerable<IModel>>(entityList);
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
