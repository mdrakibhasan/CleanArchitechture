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
    public record UpdateColor(VmColor aVmColor,int id):IRequest<VmColor>;
    public class UpdateColorHandler : IRequestHandler<UpdateColor, VmColor>
    {
        private readonly IColorRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateColorValidation _validationRules;
        public UpdateColorHandler(IColorRepository ColorRepository, IMapper mapper, UpdateColorValidation validationRules)
        {
            _Repository = ColorRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmColor> Handle(UpdateColor request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);
            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            var result = await _Repository.Update(request.id,_mapper.Map<Model.Color>(request.aVmColor));
            return result;
        }
    }
    public class UpdateColorValidation : AbstractValidator<UpdateColor>
    {
        public UpdateColorValidation()
        {
            RuleFor(x => x.aVmColor.ColorName).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
