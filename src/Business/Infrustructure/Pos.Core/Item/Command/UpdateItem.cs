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

namespace Pos.Core.Item.Command
{
    public record UpdateItem(VmItem aVmItem,int id):IRequest<VmItem>;
    public class UpdateItemHandler : IRequestHandler<UpdateItem, VmItem>
    {
        private readonly IItemRepository _Repository;
        private readonly IMapper _mapper;
        private readonly UpdateItemValidation _validationRules;
        public UpdateItemHandler(IItemRepository productRepository, IMapper mapper, UpdateItemValidation validationRules)
        {
            _Repository = productRepository;
            _mapper = mapper;
            _validationRules = validationRules;
        }

        public async Task<VmItem> Handle(UpdateItem request, CancellationToken cancellationToken)
        {
            var validation = await _validationRules.ValidateAsync(request, cancellationToken);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            var result = await _Repository.Update(request.id,_mapper.Map<Model.Item>(request.aVmItem));

            return result;
        }
    }
    public class UpdateItemValidation : AbstractValidator<UpdateItem>
    {
        public UpdateItemValidation()
        {
            RuleFor(x => x.aVmItem.Name).NotEmpty().WithMessage("Name is Requrid .");
        }
    }
}
