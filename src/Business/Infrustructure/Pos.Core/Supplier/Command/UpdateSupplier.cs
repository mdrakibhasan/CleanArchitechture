using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
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
    public record UpdateSupplier(VmSupplier aVmSupplier,int id):IRequest<VmSupplier>;
    public class UpdateSupplierHandler : IRequestHandler<UpdateSupplier, VmSupplier>
    {
        private readonly ISupplierRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateSupplierValidation _validationRules;
        public UpdateSupplierHandler(ISupplierRepository productRepository, IMapper mapper, UpdateSupplierValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmSupplier> Handle(UpdateSupplier request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var result = await _Repository.Update(request.id,_mapper.Map<Model.Supplier>(request.aVmSupplier));

            return result;
        }
    }
    public class UpdateSupplierValidation : AbstractValidator<UpdateSupplier>
    {
        public UpdateSupplierValidation()
        {
            RuleFor(x => x.aVmSupplier.Name).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
