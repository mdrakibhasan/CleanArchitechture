using AutoMapper;
using Pos.Infrustructure;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class ItemRepository:  RepositoryBase<Model.Item, VmItem, int>,IItemRepository
    {
        public ItemRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }

        
    }
}
