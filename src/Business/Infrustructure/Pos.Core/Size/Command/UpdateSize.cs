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
    public record UpdateSize(VmSize aVmSize,int id):IRequest<VmSize>;
    public class UpdateSizeHandler : IRequestHandler<UpdateSize, VmSize>
    {
        private readonly ISizeRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateSizeValidation _validationRules;
        public UpdateSizeHandler(ISizeRepository SizeRepository, IMapper mapper, UpdateSizeValidation validationRules)
        {
            _Repository = SizeRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmSize> Handle(UpdateSize request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.Size>(request.aVmSize));
            return result;
        }
    }
    public class UpdateSizeValidation : AbstractValidator<UpdateSize>
    {
        public UpdateSizeValidation()
        {
            RuleFor(x => x.aVmSize.SizeName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
