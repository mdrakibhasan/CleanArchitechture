using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pos.Repository;
using Pos.Service.Model;
using System.Threading;
using Pos.Repository.IRepository;
using Pos.IRepository;

namespace Pos.Core.Query
{
    public record GetByAccountsHeadAll() : IRequest<List<VmAccountsHead>>;
    public class GetAccountsHeadAllHandler : IRequestHandler<GetByAccountsHeadAll, List<VmAccountsHead>>
    {
		private readonly IAccountsHeadRepository _sateRepository;
		public GetAccountsHeadAllHandler(IAccountsHeadRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<List<VmAccountsHead>> Handle(GetByAccountsHeadAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetAccountsType();
			
			return result;
		}
	}
   
}
