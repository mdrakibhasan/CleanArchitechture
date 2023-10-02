using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pos.Repository;
using Pos.Service.Model;
using System.Threading;

namespace Pos.Core.Query
{
    public record GetByCategoryAll() : IRequest<IEnumerable<VmCategory>>;
    public class GetCategoryAllHandler : IRequestHandler<GetByCategoryAll, IEnumerable<VmCategory>>
    {
		private readonly ICategoryRepository _sateRepository;
		public GetCategoryAllHandler(ICategoryRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmCategory>> Handle(GetByCategoryAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
