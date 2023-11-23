using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.IRepository;
using Pos.Service.Model;
using System.Threading;    
using System.Threading.Tasks;
using Pos.Repository.IRepository;

namespace Pos.Core.Supplier.Query
{
    public record  GetBySupplierId(int id):IRequest<VmSupplier>;
    

    
    public class GetByIdHandler : IRequestHandler<GetBySupplierId, VmSupplier>
    {

        private readonly ISupplierRepository _productRepository;

        private readonly IMapper _mapper;
        private readonly GetStateByIdValtion _validationRules;

        public GetByIdHandler(ISupplierRepository productRepository,IMapper mapper, GetStateByIdValtion validationRules)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSupplier> Handle(GetBySupplierId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _productRepository.GetById(request.id);
            return result;

        }

        public class GetStateByIdValtion : AbstractValidator<GetBySupplierId>
        {
            public GetStateByIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
