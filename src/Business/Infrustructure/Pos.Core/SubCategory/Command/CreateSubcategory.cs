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

namespace Pos.Core.Command
{
    public record CreateSubcategory(VmSubcategory aVmSubcategory) :IRequest<VmSubcategory>;
    public class CreateSubcategoryHandler : IRequestHandler<CreateSubcategory, VmSubcategory>
    {
        private readonly Repository.IRepository.ISubCategoryRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateSubcategoryValidation _validationRules;
        public CreateSubcategoryHandler(Repository.IRepository.ISubCategoryRepository aRepository, IMapper mapper, CreateSubcategoryValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSubcategory> Handle(CreateSubcategory request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.SubCategory>(request.aVmSubcategory));
           
            return result;
        }
    }

    public class CreateSubcategoryValidation : AbstractValidator<CreateSubcategory>
    {
        public CreateSubcategoryValidation()
        {
            RuleFor(x => x.aVmSubcategory.SubCategoryName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
