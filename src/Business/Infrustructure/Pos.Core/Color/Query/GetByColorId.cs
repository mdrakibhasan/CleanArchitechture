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
    public record GetByColorId(int id):IRequest<VmColor>;
    

    
    public class GetByColorIdHandler : IRequestHandler<GetByColorId, VmColor>
    {

        private readonly IColorRepository _ColorRepository;

        private readonly IMapper _mapper;
        private readonly GetStateByColorIdValtion _validationRules;

        public GetByColorIdHandler(IColorRepository ColorRepository, IMapper mapper, GetStateByColorIdValtion validationRules)
        {
            _ColorRepository = ColorRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmColor> Handle(GetByColorId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _ColorRepository.GetById(request.id);
            return result;

        }

        Task<VmColor> IRequestHandler<GetByColorId, VmColor>.Handle(GetByColorId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public class GetStateByColorIdValtion : AbstractValidator<GetByColorId>
        {
            public GetStateByColorIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
