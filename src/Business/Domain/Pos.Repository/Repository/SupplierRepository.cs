using AutoMapper;
using Pos.Infrustructure;
using Pos.IRepository;
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
   public class SupplierRepository : RepositoryBase<Supplier, VmSupplier, int>, ISupplierRepository
    {
        public SupplierRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {

        }
    }
}
