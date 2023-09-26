using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Service.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Product.Command
{
   
    public record DeleteProduct( int id) : IRequest<VmProduct>;
    public class DeleteProductHandler 
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;
        public DeleteProductHandler(IProductRepository productRepository, IMapper mapper )
        {
            _Repository = productRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteProduct request, CancellationToken cancellationToken)
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
