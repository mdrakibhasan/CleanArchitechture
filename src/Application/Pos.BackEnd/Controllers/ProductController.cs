using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Product.Query;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
                
        }


        [HttpGet]
        public async Task<ActionResult<VmProduct>> GetById(int id)
        {
            return await _mediator.Send(new GetById(id));
        }
        [HttpGet]
        [Route("[action]")]
        public async Task<IEnumerable<VmProduct>> GetAll()
        {
            return await _mediator.Send(new GetByAll());
        }
    }
}
