using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Command
{
   
    public record DeleteItem( int id) : IRequest<VmItem>;
    public class DeleteItemHandler 
    {
        private readonly IItemRepository _Repository;
        private readonly IMapper _mapper;
        public DeleteItemHandler(IItemRepository productRepository, IMapper mapper )
        {
            _Repository = productRepository;
            _mapper = mapper;
        }

        public async Task Handle(DeleteItem request, CancellationToken cancellationToken)
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
