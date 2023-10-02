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
    public record CreateMOU(VmMOU aVmMOU) :IRequest<VmMOU>;
    public class CreateMOUHandler : IRequestHandler<CreateMOU, VmMOU>
    {
        private readonly IMUORepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateMOUValidation _validationRules;
        public CreateMOUHandler(IMUORepository aRepository, IMapper mapper, CreateMOUValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmMOU> Handle(CreateMOU request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.MOU>(request.aVmMOU));
           
            return result;
        }
    }

    public class CreateMOUValidation : AbstractValidator<CreateMOU>
    {
        public CreateMOUValidation()
        {
            RuleFor(x => x.aVmMOU.UniteName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
