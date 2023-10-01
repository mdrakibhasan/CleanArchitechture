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
    public class MOURepository: RepositoryBase<MOU, VmMOU, int>, IMUORepository
    {
        public MOURepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
