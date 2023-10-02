using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pos.Core.Product.Command
{
    public record UpdateSubcategory(VmSubcategory aVmSubcategory, int id):IRequest<VmSubcategory>;
    public class UpdateSubcategoryHandler : IRequestHandler<UpdateSubcategory, VmSubcategory>
    {
        private readonly ISubCategoryRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateSubcategoryValidation _validationRules;
        public UpdateSubcategoryHandler(ISubCategoryRepository SubcategoryRepository, IMapper mapper, UpdateSubcategoryValidation validationRules)
        {
            _Repository = SubcategoryRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmSubcategory> Handle(UpdateSubcategory request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.SubCategory>(request.aVmSubcategory));
            return result;
        }
    }
    public class UpdateSubcategoryValidation : AbstractValidator<UpdateSubcategory>
    {
        public UpdateSubcategoryValidation()
        {
            RuleFor(x => x.aVmSubcategory.SubCategoryName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
