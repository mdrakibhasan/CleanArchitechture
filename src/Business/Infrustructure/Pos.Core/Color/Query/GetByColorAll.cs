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
    public record GetByColorAll() : IRequest<IEnumerable<VmColor>>;
    public class GetColorAllHandler : IRequestHandler<GetByColorAll, IEnumerable<VmColor>>
    {
		private readonly IColorRepository _sateRepository;
		public GetColorAllHandler(IColorRepository sateRepository)
		{
			_sateRepository = sateRepository;
		}
		public async Task<IEnumerable<VmColor>> Handle(GetByColorAll request, CancellationToken cancellationToken)
		{
			var result = await _sateRepository.GetList();
			;
			return result;
		}
	}
   
}
