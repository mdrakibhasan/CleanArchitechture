using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pos.Repository;
using Pos.Service.Model;
using System.Threading;

namespace Pos.Core.Product.Query
{
    public record GetByAll() : IRequest<IEnumerable<VmProduct>>;
    public class GetAllHandler:IRequestHandler<GetByAll,IEnumerable<VmProduct>>
    {
		private readonly IProductRepository _sateRepository;
		public GetAllHandler(IProductRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmProduct>> Handle(GetByAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
