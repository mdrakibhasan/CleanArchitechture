using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Service.Model;

using System.Threading;


    
using System.Threading.Tasks;

namespace Pos.Core.Product.Query
{
    public record  GetById(int id):IRequest<VmProduct>;
    

    
    public class GetByIdHandler : IRequestHandler<GetById, VmProduct>
    {

        private readonly IProductRepository _productRepository;

        private readonly IMapper _mapper;
        private readonly GetStateByIdValtion _validationRules;

        public GetByIdHandler(IProductRepository productRepository,IMapper mapper, GetStateByIdValtion validationRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmProduct> Handle(GetById request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _productRepository.GetById(request.id);
            return result;

        }

        public class GetStateByIdValtion : AbstractValidator<GetById>
        {
            public GetStateByIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
