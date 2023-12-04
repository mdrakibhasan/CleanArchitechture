﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Pos.Infrustructure;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.Repository
{
    public class AccountsReportReposity: IAccountsReportReposity
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;
        public AccountsReportReposity(IMapper mapper, PosDbContext dbContext) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<VmAccountsTrialBalanceSheet> GetTrialBalance(int Level, DateTime FromDate, DateTime ToDate)
        {
            var Data = _dbContext.AccountsHeads.Include(a => a.HeadLeaf).Include(a => a.AccountsHeadType).Where(a => a.RootId == null).AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
            List<VmAccountsHeadDetails> levelList=new List<VmAccountsHeadDetails>();
            VmAccountsTrialBalanceSheet _vmAccountsTrialBalanceSheet = new VmAccountsTrialBalanceSheet();  
            if (Level==1)
            {
                _vmAccountsTrialBalanceSheet.AccountsHeadDetails= (from a in _vmAccountsHeads
                                                                   
                                                                   select new VmAccountsHeadDetails
                                                                   {
                                                                       AccountCode=a.Code,
                                                                       AccountsType=a.AccountsHeadTypeName,
                                                                       HeadId=a.Id,
                                                                       CreditedAmount=0,
                                                                       DebitedAmount=0,
                                                                       Balance=0,
                                                                       PrevBalance=0,
                                                                       HeadName=a.HeadName,
                                                                   }
                                                                   ).ToList();
            }
            else
            {
                for (int i=2;i<=4;i++)
                {
                    if(i==Level)
                    {
                        //levelList.AddRange(from);
                    }
                    else
                    {
                        
                    }
                }
                foreach (var data in _vmAccountsHeads)
                {
                    if (data.RootLeaf != "L")
                    {
                        data.HeadLeaf = await GetAccountsTypeLeafList(data);
                    }
                    else
                    {
                        _vmAccountsTrialBalanceSheet.AccountsHeadDetails.Add( new VmAccountsHeadDetails
                                                                            {
                                                                                AccountCode = data.Code,
                                                                                AccountsType = data.AccountsHeadTypeName,
                                                                                HeadId = data.Id,
                                                                                CreditedAmount = 0,
                                                                                DebitedAmount = 0,
                                                                                Balance = 0,
                                                                                PrevBalance = 0,
                                                                                HeadName = data.HeadName,
                                                                            }
                                                                   );
                    }

                }
            }


            return  _vmAccountsTrialBalanceSheet;
        }
        public async Task<IEnumerable<VmAccountsHead>> GetAccountsType()
        {

            var Data = _dbContext.AccountsHeads.Include(a => a.HeadLeaf).Where(a => a.RootId == null).AsAsyncEnumerable();
            var _vmAccountsHeads = _mapper.Map<IEnumerable<VmAccountsHead>>(Data);
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
        public async Task<List<VmAccountLadger>> GetAccountsLadger(int AccountsHeadId, DateTime FromDate, DateTime ToDate)
        {
            var PBal = await _dbContext.AccountTransactionDtl.Where(a => a.AccountsHeadId == AccountsHeadId && a.AccountTransactionMst.VoucherDate.Date < FromDate).GroupBy(x => new { x.AccountsHeadId }).Select(a => new { CreditedAmount = a.Sum(g => g.CreditedAmount), DebitedAmount = a.Sum(g => g.DebitedAmount), a.Key.AccountsHeadId }).ToListAsync();

            var Data = await _dbContext.AccountTransactionDtl.Include(a => a.AccountTransactionMst).Include(a => a.AccountsHead).Where(a => a.AccountsHeadId == AccountsHeadId && a.AccountTransactionMst.VoucherDate.Date >= FromDate && a.AccountTransactionMst.VoucherDate.Date <= ToDate).ToListAsync();
            var res = Data.Select((a, index) =>
           new VmAccountLadger
           {
               HeadName = a.AccountsHead.HeadName,
               VoucherNo = a.AccountTransactionMst.VoucherNo,
               CompanyId = a.AccountTransactionMst.CompanyId,
               Particulars = a.AccountTransactionMst.Particulars,
               ManualVoucherNo = a.AccountTransactionMst.ManualVoucherNo,
               VoucherType = a.AccountTransactionMst.VoucherType,
               CreditedAmount = a.CreditedAmount,
               PrevBalance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0),
               DebitedAmount = a.DebitedAmount,
               VoucherDate = a.AccountTransactionMst.VoucherDate.ToLocalTime().ToString("dd/MM/yyyy"),
               Balance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0) + (Data.Take(index + 1).Sum(x => x.DebitedAmount) ?? 0) - (Data.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0),
               LineNo = a.LineNo,
               Id = a.Id,
           }).ToList();
            return res;
        }
        public async Task<VmAccountTransactionMst> GetTransactionDetails(int TranMstId)
        {
            var tranmst = await _dbContext.AccountTransactionMst.Include(a => a.AccountsDtl).ThenInclude(a => a.AccountsHead).Where(a => a.Id == TranMstId).SingleOrDefaultAsync();
            var _vmAccountsHeads = _mapper.Map<VmAccountTransactionMst>(tranmst);

            _vmAccountsHeads.AccountsDtl = tranmst.AccountsDtl.Select((a, index) =>
           new VmAccountTransactionDtl
           {
               HeadName = a.AccountsHead.HeadName,
               AccountTransactionMstID = a.AccountTransactionMstID,
               AccountsHeadId = a.AccountsHeadId,
               Particulars = _vmAccountsHeads.Particulars,
               CreditedAmount = a.CreditedAmount,
               DebitedAmount = a.DebitedAmount,
               LineNo = a.LineNo,

               Id = a.Id,
           }).ToList();
            return _vmAccountsHeads;
        }

        public async Task<VmAccountsHead> GetAccountsLadgerByRootId(int AccountsHeadId, DateTime FromDate, DateTime ToDate)
        {
            // var PBal = await _dbContext.AccountTransactionDtl.Where(a => a.AccountsHeadId == AccountsHeadId && a.AccountTransactionMst.VoucherDate.Date < FromDate).GroupBy(x => new { x.AccountsHeadId }).Select(a => new { CreditedAmount = a.Sum(g => g.CreditedAmount), DebitedAmount = a.Sum(g => g.DebitedAmount), a.Key.AccountsHeadId }).ToListAsync();

            var Data = await _dbContext.AccountsHeads.Include(a => a.HeadLeaf).SingleOrDefaultAsync(a => a.Id == AccountsHeadId);
            var _vmAccountsHeads = _mapper.Map<VmAccountsHead>(Data);

            if (_vmAccountsHeads.RootLeaf != null && _vmAccountsHeads.RootLeaf != "L")
            {

                _vmAccountsHeads.vmAccountLadgers = new List<VmAccountLadger>();
                var vmdata = await GetAccountsTransactionList(_vmAccountsHeads, FromDate, ToDate);
                var data = vmdata.OrderBy(a => a.Id).ToList();
                _vmAccountsHeads.vmAccountLadgers = data.Select((a, index) =>
               new VmAccountLadger
               {
                   HeadName = a.HeadName,
                   VoucherNo = a.VoucherNo,
                   CompanyId = a.CompanyId,
                   Particulars = a.Particulars,
                   ManualVoucherNo = a.ManualVoucherNo,
                   VoucherType = a.VoucherType,
                   CreditedAmount = a.CreditedAmount,
                   PrevBalance = (data.Sum(c => c.PrevBalance) ?? 0),
                   DebitedAmount = a.DebitedAmount,
                   VoucherDate = a.VoucherDate,
                   PrevCreditedAmount = data.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0,
                   PrevDebitedAmount = data.Take(index + 1).Sum(x => x.DebitedAmount) ?? 0,
                   Balance = (data.Sum(c => c.PrevBalance) ?? 0) + (data.Take(index + 1).Sum(x => x.DebitedAmount) ?? 0) - (data.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0),
                   LineNo = a.LineNo,
                   Id = a.Id,
                   TranMstId = a.TranMstId,
               }).OrderBy(a => a.Id).ToList();
            }
            else
            {
                var Datad = await _dbContext.AccountTransactionDtl.Include(a => a.AccountTransactionMst).Where(a => a.AccountsHeadId == _vmAccountsHeads.Id && a.AccountTransactionMst.VoucherDate.Date >= FromDate && a.AccountTransactionMst.VoucherDate.Date <= ToDate).ToListAsync();

                var PBal = await _dbContext.AccountTransactionDtl.Where(a => a.AccountsHeadId == _vmAccountsHeads.Id && a.AccountTransactionMst.VoucherDate.Date < FromDate).GroupBy(x => new { x.AccountsHeadId }).Select(a => new { CreditedAmount = a.Sum(g => g.CreditedAmount), DebitedAmount = a.Sum(g => g.DebitedAmount), a.Key.AccountsHeadId }).ToListAsync();

                var res = Datad.Select((a, index) =>
                new VmAccountLadger
                {
                    HeadName = a.AccountsHead.HeadName,
                    VoucherNo = a.AccountTransactionMst.VoucherNo,
                    CompanyId = a.AccountTransactionMst.CompanyId,
                    Particulars = a.AccountTransactionMst.Particulars,
                    ManualVoucherNo = a.AccountTransactionMst.ManualVoucherNo,
                    PrevBalance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0),
                    VoucherType = a.AccountTransactionMst.VoucherType,
                    CreditedAmount = a.CreditedAmount,
                    DebitedAmount = a.DebitedAmount,
                    VoucherDate = a.AccountTransactionMst.VoucherDate.ToLocalTime().ToString("dd/MM/yyyy"),
                    Balance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0) + (Datad.Take(index + 1).Sum(x => x.DebitedAmount) ?? 0) - (Datad.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0),
                    LineNo = a.LineNo,
                    Id = a.Id,
                    TranMstId = a.AccountTransactionMstID,


                }).ToList();
                _vmAccountsHeads.vmAccountLadgers = new List<VmAccountLadger>();
                _vmAccountsHeads.vmAccountLadgers.AddRange(res);
            }



            return _vmAccountsHeads;
        }
        //call baack Function
        public async Task<List<VmAccountLadger>> GetAccountsTransactionList(VmAccountsHead aVmAccountsHead, DateTime FromDate, DateTime ToDate)
        {
            if (aVmAccountsHead.vmAccountLadgers == null)
            {
                aVmAccountsHead.vmAccountLadgers = new List<VmAccountLadger>();
            }
            if (aVmAccountsHead.HeadLeaf.Count > 0)
            {
                foreach (var data in aVmAccountsHead.HeadLeaf)
                {
                    if (data.RootLeaf == "L")
                    {

                        var Datarec = await _dbContext.AccountTransactionDtl.Include(a => a.AccountTransactionMst).Where(a => a.AccountsHeadId == data.Id && a.AccountTransactionMst.VoucherDate.Date >= FromDate && a.AccountTransactionMst.VoucherDate.Date <= ToDate).OrderBy(a => a.Id).ToListAsync();

                        var PBal = await _dbContext.AccountTransactionDtl.Where(a => a.AccountsHeadId == data.Id && a.AccountTransactionMst.VoucherDate.Date < FromDate).GroupBy(x => new { x.AccountsHeadId }).Select(a => new { CreditedAmount = a.Sum(g => g.CreditedAmount), DebitedAmount = a.Sum(g => g.DebitedAmount), a.Key.AccountsHeadId }).ToListAsync();

                        var res = Datarec.Select((a, index) =>
                        new VmAccountLadger
                        {
                            HeadName = a.AccountsHead.HeadName,
                            VoucherNo = a.AccountTransactionMst.VoucherNo,
                            CompanyId = a.AccountTransactionMst.CompanyId,
                            Particulars = a.AccountTransactionMst.Particulars,
                            ManualVoucherNo = a.AccountTransactionMst.ManualVoucherNo,
                            VoucherType = a.AccountTransactionMst.VoucherType,
                            PrevBalance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0),
                            CreditedAmount = a.CreditedAmount,
                            DebitedAmount = a.DebitedAmount,
                            VoucherDate = a.AccountTransactionMst.VoucherDate.ToLocalTime().ToString("dd/MM/yyyy"),
                            Balance = (PBal.Sum(c => c.DebitedAmount) ?? 0) - (PBal.Sum(c => c.CreditedAmount) ?? 0) + (Datarec.Take(index + 1).Sum(x => x.DebitedAmount) ?? 0) - (Datarec.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0),
                            LineNo = a.LineNo,
                            Id = a.Id,
                            TranMstId = a.AccountTransactionMstID,
                        }).ToList();

                        aVmAccountsHead.vmAccountLadgers.AddRange(res);

                    }
                    else
                    {
                        var Data2 = await _dbContext.AccountsHeads.Include(a => a.HeadLeaf).SingleOrDefaultAsync(a => a.Id == data.Id);
                        var vmdata = _mapper.Map<VmAccountsHead>(Data2);

                        aVmAccountsHead.vmAccountLadgers.AddRange(await GetAccountsTransactionList(vmdata, FromDate, ToDate));

                    }

                }
            }
            return aVmAccountsHead.vmAccountLadgers;
        }
    }
}
