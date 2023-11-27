using Pos.Model;
using Pos.Service.Model;
using Pos.Shared.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos.Repository.IRepository
{
    public interface IAccountsHeadRepository : IRepository<AccountsHead, VmAccountsHead, int>
    {
        Task<IEnumerable<VmAccountsHead>> GetAccountsType();
    }
}
