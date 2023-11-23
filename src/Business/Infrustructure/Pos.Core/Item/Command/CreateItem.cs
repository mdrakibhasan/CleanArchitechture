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
    public record CreateItem(VmItem aVmItem):IRequest<VmItem>;
    public class CreateItemHandler : IRequestHandler<CreateItem, VmItem>
    {
        private readonly IItemRepository _Repository;
        private readonly IMapper _mapper;
        private readonly CreateItemValidation _validationRules;
        public CreateItemHandler(IItemRepository productRepository, IMapper mapper, CreateItemValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }
        public async Task<VmItem> Handle(CreateItem request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }
            
            var result = await _Repository.Add(_mapper.Map<Model.Item>(request.aVmItem));
           
            return result;
        }
    }

    public class CreateItemValidation : AbstractValidator<CreateItem>
    {
        public CreateItemValidation()
        {
            RuleFor(x => x.aVmItem.Name).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
