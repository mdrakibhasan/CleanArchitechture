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

namespace Pos.Core.Query
{
    public record GetByItemAll() : IRequest<IEnumerable<VmItem>>;
    public class GetAllHandler:IRequestHandler<GetByItemAll,IEnumerable<VmItem>>
    {
		private readonly IItemRepository _sateRepository;
		public GetAllHandler(IItemRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmItem>> Handle(GetByItemAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			return result;
		}
	}
   
}
