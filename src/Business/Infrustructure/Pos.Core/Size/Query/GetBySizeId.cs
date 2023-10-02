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
    public record GetBySizeId(int id):IRequest<VmSize>;
    

    
    public class GetBySizeIdHandler : IRequestHandler<GetBySizeId, VmSize>
    {

        private readonly ISizeRepository _SizeRepository;

        private readonly IMapper _mapper;
        private readonly GetStateBySizeIdValtion _validationRules;

        public GetBySizeIdHandler(ISizeRepository SizeRepository, IMapper mapper, GetStateBySizeIdValtion validationRules)
        {
            _SizeRepository = SizeRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSize> Handle(GetBySizeId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _SizeRepository.GetById(request.id);
            return result;

        }

        Task<VmSize> IRequestHandler<GetBySizeId, VmSize>.Handle(GetBySizeId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public class GetStateBySizeIdValtion : AbstractValidator<GetBySizeId>
        {
            public GetStateBySizeIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
