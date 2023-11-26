using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using Pos.Infrustructure;
using Pos.IRepository;
using Pos.Model;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using Pos.Shared;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class AccountsHeadRepository: RepositoryBase<AccountsHead, VmAccountsHead, int>, IAccountsHeadRepository
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;
        public AccountsHeadRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<VmAccountsHead>> GetAccountsType()
        {

           
         var Data=   await _dbContext.AccountsHeads.Include(a=>a.HeadLeaf).ToListAsync();
            return _mapper.Map<List<VmAccountsHead>>(Data);
        }
    }
}
