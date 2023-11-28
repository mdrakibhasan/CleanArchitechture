using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
    public class AccountsTransactionRepository : RepositoryBase<AccountTransactionMst, VmAccountTransactionMst, int>, IAccountsTransactionRepository
    {
        private readonly IMapper _mapper;
        private readonly PosDbContext _dbContext;
        public AccountsTransactionRepository(IMapper mapper, PosDbContext dbContext) : base(mapper, dbContext)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<List<VmAccountLadger>> GetAccountsLadger(int AccountsHeadId,DateTime FromDate,DateTime ToDate)
        {
            var PBal = await _dbContext.AccountTransactionDtl.Where(a => a.AccountsHeadId == AccountsHeadId && a.AccountTransactionMst.VoucherDate.Date < FromDate).GroupBy(x=>new { x.AccountsHeadId}).Select(a=> new { CreditedAmount = a.Sum(g=>g.CreditedAmount), DebitedAmount = a.Sum(g => g.DebitedAmount),a.Key.AccountsHeadId }).ToListAsync();

            var Data =await _dbContext.AccountTransactionDtl.Include(a => a.AccountTransactionMst).Include(a => a.AccountsHead).Where(a => a.AccountsHeadId == AccountsHeadId && a.AccountTransactionMst.VoucherDate.Date>= FromDate && a.AccountTransactionMst.VoucherDate.Date <= ToDate).ToListAsync();
            var res = Data.Select((a, index) =>
           new VmAccountLadger  {
               HeadName= a.AccountsHead.HeadName,
               VoucherNo= a.AccountTransactionMst.VoucherNo,
               CompanyId=a.AccountTransactionMst.CompanyId,
               Particulars = a.AccountTransactionMst.Particulars,
               ManualVoucherNo = a.AccountTransactionMst.ManualVoucherNo, VoucherType=a.AccountTransactionMst.VoucherType,
               CreditedAmount=a.CreditedAmount,
               DebitedAmount=a.DebitedAmount,
               VoucherDate=a.AccountTransactionMst.VoucherDate.ToLocalTime().ToString("dd/MM/yyyy"),
               Balance= (PBal.Sum(c => c.DebitedAmount) ?? 0) -(PBal.Sum(c=>c.CreditedAmount)??0 )+   (Data.Take(index+1).Sum(x=>x.DebitedAmount)??0)- (Data.Take(index + 1).Sum(x => x.CreditedAmount) ?? 0),
               LineNo= a.LineNo,
               Id=a.Id,
            }).ToList();           
            return res;
        }
    }
}
