using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Product.Command
{
    public record CreateProduct(VmProduct aVmProduct):IRequest<VmProduct>;
    public class CreateProductHandler : IRequestHandler<CreateProduct, VmProduct>
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateProductValidation _validationRules;
        public CreateProductHandler(IProductRepository productRepository, IMapper mapper, CreateProductValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmProduct> Handle(CreateProduct request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Product>(request.aVmProduct));
           
            return result;
        }
    }

    public class CreateProductValidation : AbstractValidator<CreateProduct>
    {
        public CreateProductValidation()
        {
            RuleFor(x => x.aVmProduct.ProductName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
