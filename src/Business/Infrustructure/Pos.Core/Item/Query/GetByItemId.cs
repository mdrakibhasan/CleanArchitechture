using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Service.Model;

using System.Threading;


    
using System.Threading.Tasks;

namespace Pos.Core.Query
{
    public record GetByItemId(int id):IRequest<VmItem>;
    

    
    public class GetByItemIdHandler : IRequestHandler<GetByItemId, VmItem>
    {

        private readonly IItemRepository _ItemRepository;

        private readonly IMapper _mapper;
        private readonly GetStateByItemIdValtion _validationRules;

        public GetByItemIdHandler(IItemRepository ItemRepository, IMapper mapper, GetStateByItemIdValtion validationRules)
        {
            _ItemRepository = ItemRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmItem> Handle(GetByItemId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _ItemRepository.GetById(request.id);
            return result;

        }

        Task<VmItem> IRequestHandler<GetByItemId, VmItem>.Handle(GetByItemId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public class GetStateByItemIdValtion : AbstractValidator<GetByItemId>
        {
            public GetStateByItemIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
