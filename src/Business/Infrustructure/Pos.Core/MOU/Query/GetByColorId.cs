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
    public record GetByMOUId(int id):IRequest<VmMOU>;
    

    
    public class GetByMOUIdHandler : IRequestHandler<GetByMOUId, VmMOU>
    {

        private readonly IMUORepository _MOURepository;

        private readonly IMapper _mapper;
        private readonly GetStateByMOUIdValtion _validationRules;

        public GetByMOUIdHandler(IMUORepository MOURepository, IMapper mapper, GetStateByMOUIdValtion validationRules)
        {
            _MOURepository = MOURepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmMOU> Handle(GetByMOUId request, CancellationToken cancellationToken)
        {

            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if(!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _MOURepository.GetById(request.id);
            return result;

        }

        Task<VmMOU> IRequestHandler<GetByMOUId, VmMOU>.Handle(GetByMOUId request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public class GetStateByMOUIdValtion : AbstractValidator<GetByMOUId>
        {
            public GetStateByMOUIdValtion()
            {
                RuleFor(x => x.id).NotEmpty().WithMessage("Id is Requrid .");
            }
        }
    }
}
