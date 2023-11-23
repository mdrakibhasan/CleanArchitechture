using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Service.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Command
{
   
    public record DeleteSupplier( int id) : IRequest<VmSupplier>;
    public class DeleteSupplierHandler 
    {
        private readonly ISupplierRepository _Repository;
        private readonly IMapper _mapper;
        public DeleteSupplierHandler(ISupplierRepository productRepository, IMapper mapper )
        {
            _Repository = productRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteSupplier request, CancellationToken cancellationToken)
        {
            var validation = await _Repository.GetById(request.id);

            if (validation==null)
            {
                throw new ValidationException("Data Not Found");
            }

            await _Repository.Delete(request.id);

        }
    }
   
}
