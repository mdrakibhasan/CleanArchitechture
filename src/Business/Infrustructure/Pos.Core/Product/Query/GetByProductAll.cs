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
    public record GetByProductAll() : IRequest<IEnumerable<VmProduct>>;
    public class GetAllHandler:IRequestHandler<GetByProductAll,IEnumerable<VmProduct>>
    {
		private readonly IProductRepository _sateRepository;
		public GetAllHandler(IProductRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmProduct>> Handle(GetByProductAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
