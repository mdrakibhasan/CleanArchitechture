using MediatR;
using Pos.Core.Query;
using Pos.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Supplier.Query
{
    public record  GetBySupplierAll : IRequest<IEnumerable<VmSupplier>>;
	public class GetSupplierllHandler : IRequestHandler<GetBySupplierAll, IEnumerable<VmSupplier>>
	{
		private readonly ISupplierRepository _sateRepository;
		public GetSupplierllHandler(ISupplierRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmSupplier>> Handle(GetBySupplierAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			return result;
		}
	}
}
