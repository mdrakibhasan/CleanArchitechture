using AutoMapper;
using Pos.Infrustructure;
using Pos.Model;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository
{
    public class CategoryRepository : RepositoryBase<Category, VmCategory, int>, ICategoryRepository
    {
        public CategoryRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
