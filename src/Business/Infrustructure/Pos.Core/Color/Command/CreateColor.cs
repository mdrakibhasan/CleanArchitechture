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
    public record CreateColor(VmColor aVmColor) :IRequest<VmColor>;
    public class CreateColorHandler : IRequestHandler<CreateColor, VmColor>
    {
        private readonly IColorRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateColorValidation _validationRules;
        public CreateColorHandler(IColorRepository aRepository, IMapper mapper, CreateColorValidation validationRules)
        {
            _Repository = aRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmColor> Handle(CreateColor request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Color>(request.aVmColor));
           
            return result;
        }
    }

    public class CreateColorValidation : AbstractValidator<CreateColor>
    {
        public CreateColorValidation()
        {
            RuleFor(x => x.aVmColor.ColorName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
