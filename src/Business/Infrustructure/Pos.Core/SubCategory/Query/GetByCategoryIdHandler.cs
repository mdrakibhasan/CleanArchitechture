using AutoMapper;
using FluentValidation;
using MediatR;
using Pos.Repository;
using Pos.Repository.IRepository;
using Pos.Service.Model;

using System.Threading;


    
using System.Threading.Tasks;

namespace Pos.Core.Product.Query
{
    public record GetBySubcategoryId(int id):IRequest<VmSubcategory>;
    

    
    public class GetBySubcategoryIdHandler : IRequestHandler<GetBySubcategoryId, VmSubcategory>
    {

        private readonly ISubCategoryRepository _SubcategoryRepository;

        private readonly IMapper _mapper;
        private readonly GetStateBySubcategoryIdValtion _validationRules;

        public GetBySubcategoryIdHandler(ISubCategoryRepository SubcategoryRepository, IMapper mapper, GetStateBySubcategoryIdValtion validationRules)
        {
            _SubcategoryRepository = SubcategoryRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSubcategory> Handle(GetBySubcategoryId request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _SubcategoryRepository.GetById(request.id);
            return result;
        }
        Task<VmSubcategory> IRequestHandler<GetBySubcategoryId, VmSubcategory>.Handle(GetBySubcategoryId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        public class GetStateBySubcategoryIdValtion : AbstractValidator<GetBySubcategoryId>
        {
            public GetStateBySubcategoryIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
