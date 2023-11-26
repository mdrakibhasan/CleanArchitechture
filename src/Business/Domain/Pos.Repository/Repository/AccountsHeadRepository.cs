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
        List<VmAccountsHead> _vmAccountsHeads = new List<VmAccountsHead>();
        public AccountsHeadRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        



        public async Task<List<VmAccountsHead>> GetAccountsType()
        {


            var Data = await _dbContext.AccountsHeads.Include(a => a.HeadLeaf).ToListAsync();
            _vmAccountsHeads = _mapper.Map<List<VmAccountsHead>>(Data);


            return _mapper.Map<List<VmAccountsHead>>(_vmAccountsHeads);
        }

        public async Task<List<VmAccountsHead>> GetAccountsTypeLeafList(VmAccountsHead aVmAccountsHead)
        {
            if (aVmAccountsHead.HeadLeaf.Count > 0)
            {
                foreach (var data in aVmAccountsHead.HeadLeaf)
                {
                    var Datarec = await _dbContext.AccountsHeads.Include(a => a.HeadLeaf).ToListAsync();
                    var datavm = _mapper.Map<List<VmAccountsHead>>(Datarec);
                    foreach (VmAccountsHead data2 in datavm)
                    {
                        data2.HeadLeaf = await GetAccountsTypeLeafList(data2);
                    }

                    data.HeadLeaf = datavm;
                }
                var Data = await _dbContext.AccountsHeads.Include(a => a.HeadLeaf).ToListAsync();

            }




            return aVmAccountsHead.HeadLeaf;
        }
    }
}
