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

namespace Pos.Core.Product.Query
{
    public record GetByMOUAll() : IRequest<IEnumerable<VmMOU>>;
    public class GetMOUAllHandler : IRequestHandler<GetByMOUAll, IEnumerable<VmMOU>>
    {
		private readonly IMUORepository _sateRepository;
		public GetMOUAllHandler(IMUORepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmMOU>> Handle(GetByMOUAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
