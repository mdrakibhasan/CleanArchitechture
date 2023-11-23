using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Command
{
    public record CreateSupplier(VmSupplier aVmSupplier):IRequest<VmSupplier>;
    public class CreateSupplierHandler : IRequestHandler<CreateSupplier, VmSupplier>
    {
        private readonly ISupplierRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateSupplierValidation _validationRules;
        public CreateSupplierHandler(ISupplierRepository productRepository, IMapper mapper, CreateSupplierValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSupplier> Handle(CreateSupplier request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Supplier>(request.aVmSupplier));
           
            return result;
        }
    }

    public class CreateSupplierValidation : AbstractValidator<CreateSupplier>
    {
        public CreateSupplierValidation()
        {
            RuleFor(x => x.aVmSupplier.Name).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
