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
    public record UpdateMOU(VmMOU aVmMOU,int id):IRequest<VmMOU>;
    public class UpdateMOUHandler : IRequestHandler<UpdateMOU, VmMOU>
    {
        private readonly IMUORepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateMOUValidation _validationRules;
        public UpdateMOUHandler(IMUORepository MOURepository, IMapper mapper, UpdateMOUValidation validationRules)
        {
            _Repository = MOURepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmMOU> Handle(UpdateMOU request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.MOU>(request.aVmMOU));
            return result;
        }
    }
    public class UpdateMOUValidation : AbstractValidator<UpdateMOU>
    {
        public UpdateMOUValidation()
        {
            RuleFor(x => x.aVmMOU.UniteName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
