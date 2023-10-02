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
    public record GetSizeAll() : IRequest<IEnumerable<VmSize>>;
    public class GetSizeAllHandler : IRequestHandler<GetSizeAll, IEnumerable<VmSize>>
    {
		private readonly ISizeRepository _sateRepository;
		public GetSizeAllHandler(ISizeRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmSize>> Handle(GetSizeAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
