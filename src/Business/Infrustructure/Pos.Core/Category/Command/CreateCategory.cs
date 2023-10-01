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

namespace Pos.Core.Command
{
    public record CreateCategory(VmCategory aVmCategory) :IRequest<VmCategory>;
    public class CreateCategoryHandler : IRequestHandler<CreateCategory, VmCategory>
    {
        private readonly ICategoryRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateCategoryValidation _validationRules;
        public CreateCategoryHandler(ICategoryRepository aRepository, IMapper mapper, CreateCategoryValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmCategory> Handle(CreateCategory request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Category>(request.aVmCategory));
           
            return result;
        }
    }

    public class CreateCategoryValidation : AbstractValidator<CreateCategory>
    {
        public CreateCategoryValidation()
        {
            RuleFor(x => x.aVmCategory.CategoryName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
