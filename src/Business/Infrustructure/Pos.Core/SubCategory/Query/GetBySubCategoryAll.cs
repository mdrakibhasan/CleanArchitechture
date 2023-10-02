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
    public record GetBySubCategoryAll() : IRequest<IEnumerable<VmSubcategory>>;
    public class GetSubcategoryAllHandler : IRequestHandler<GetBySubCategoryAll, IEnumerable<VmSubcategory>>
    {
		private readonly ISubCategoryRepository _sateRepository;
		public GetSubcategoryAllHandler(ISubCategoryRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmSubcategory>> Handle(GetBySubCategoryAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
