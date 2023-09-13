using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Shared.GenericRepository
{
    public interface IRepository<in TEntity,IModel,T>

        where TEntity:class,IEntity
        where IModel:class, IVm

        where T:IEquatable<T>
    {



        public Task<IModel> GetById(T id);

        public Task<IEnumerable<IModel>> GetList();

        public Task Delete(T id);

        public Task<IModel> Update(T id, TEntity entity);


        public Task<IModel> Add(TEntity entity);



    }
}




