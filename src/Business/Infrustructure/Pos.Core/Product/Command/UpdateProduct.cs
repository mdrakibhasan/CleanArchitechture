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
    public record UpdateProduct(VmProduct aVmProduct,int id):IRequest<VmProduct>;
    public class UpdateProductHandler : IRequestHandler<UpdateProduct, VmProduct>
    {
        private readonly IProductRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateProductValidation _validationRules;
        public UpdateProductHandler(IProductRepository productRepository, IMapper mapper, UpdateProductValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmProduct> Handle(UpdateProduct request, CancellationToken cancellationToken)
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
    public class UpdateProductValidation : AbstractValidator<UpdateProduct>
    {
        public UpdateProductValidation()
        {
            RuleFor(x => x.aVmProduct.ProductName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
