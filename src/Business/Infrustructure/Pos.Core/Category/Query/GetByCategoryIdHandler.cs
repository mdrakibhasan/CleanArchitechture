using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Service.Model;

using System.Threading;


    
using System.Threading.Tasks;

namespace Pos.Core.Product.Query
{
    public record GetByCategoryId(int id):IRequest<VmCategory>;
    

    
    public class GetByCategoryIdHandler : IRequestHandler<GetByCategoryId, VmCategory>
    {

        private readonly ICategoryRepository _CategoryRepository;

        private readonly IMapper _mapper;
        private readonly GetStateByCategoryIdValtion _validationRules;

        public GetByCategoryIdHandler(ICategoryRepository CategoryRepository, IMapper mapper, GetStateByCategoryIdValtion validationRules)
        {
            _CategoryRepository = CategoryRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmCategory> Handle(GetByCategoryId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _CategoryRepository.GetById(request.id);
            return result;

        }

        Task<VmCategory> IRequestHandler<GetByCategoryId, VmCategory>.Handle(GetByCategoryId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public class GetStateByCategoryIdValtion : AbstractValidator<GetByCategoryId>
        {
            public GetStateByCategoryIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
