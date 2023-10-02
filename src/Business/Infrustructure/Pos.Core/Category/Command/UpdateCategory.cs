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
    public record UpdateCategory(VmCategory aVmCategory,int id):IRequest<VmCategory>;
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategory, VmCategory>
    {
        private readonly ICategoryRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateCategoryValidation _validationRules;
        public UpdateCategoryHandler(ICategoryRepository CategoryRepository, IMapper mapper, UpdateCategoryValidation validationRules)
        {
            _Repository = CategoryRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmCategory> Handle(UpdateCategory request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.Category>(request.aVmCategory));
            return result;
        }
    }
    public class UpdateCategoryValidation : AbstractValidator<UpdateCategory>
    {
        public UpdateCategoryValidation()
        {
            RuleFor(x => x.aVmCategory.CategoryName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
