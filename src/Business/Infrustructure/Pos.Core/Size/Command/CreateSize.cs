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
    public record CreateSize(VmSize aVmSize) :IRequest<VmSize>;
    public class CreateSizeHandler : IRequestHandler<CreateSize, VmSize>
    {
        private readonly ISizeRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateSizeValidation _validationRules;
        public CreateSizeHandler(ISizeRepository aRepository, IMapper mapper, CreateSizeValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmSize> Handle(CreateSize request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Size>(request.aVmSize));
           
            return result;
        }
    }

    public class CreateSizeValidation : AbstractValidator<CreateSize>
    {
        public CreateSizeValidation()
        {
            RuleFor(x => x.aVmSize.SizeName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
