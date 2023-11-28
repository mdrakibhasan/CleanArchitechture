﻿using AutoMapper;
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
using Pos.Infrustructure.Migrations;

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

        



        public async Task<IEnumerable<VmAccountsHead>> GetAccountsType()
        {

            var Data =  _dbContext.AccountsHeads.Include(a => a.HeadLeaf).Where(a=>a.RootId==null).AsAsyncEnumerable();
            var   _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
            foreach (var data in _vmAccountsHeads)
            {     
                if (data.RootLeaf != "L")
                {
                    data.HeadLeaf = await GetAccountsTypeLeafList(data);
                }

            }
            return _vmAccountsHeads;
        }
        // Call Back Function for Accounts Head > Child List
        public async Task<List<VmAccountsHead>> GetAccountsTypeLeafList(VmAccountsHead aVmAccountsHead)
        {
            if (aVmAccountsHead.HeadLeaf.Count > 0)
            {
                foreach (var data in aVmAccountsHead.HeadLeaf)
                {
                    if (data.RootLeaf != "L")
                    {
                        var Datarec = await _dbContext.AccountsHeads.Where(a => a.RootId == data.Id).Include(a => a.HeadLeaf).ToListAsync();
                        var datavm = _mapper.Map<List<VmAccountsHead>>(Datarec);
                        foreach (VmAccountsHead data2 in datavm)
                        {
                            data2.HeadLeaf = await GetAccountsTypeLeafList(data2);
                        }
                        data.HeadLeaf = datavm;
                    }
                }
            }
            return aVmAccountsHead.HeadLeaf;
        }
    }
}