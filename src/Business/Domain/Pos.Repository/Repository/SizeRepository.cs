using AutoMapper;
using Pos.Infrustructure;
using Pos.Model;
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
    public class SizeRepository: RepositoryBase<Size, VmSize, int>, ISizeRepository
    {
        public SizeRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
