﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Product.Command;
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


       
        [HttpGet("{id}", Name = "GetProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmProduct>> GetProduct(int id)
        {
            return await _mediator.Send(new GetByProductId(id));
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmProduct>> GetProductAll()
        {
            return await _mediator.Send(new GetByProductAll());
        }
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmProduct>> Post([FromBody] VmProduct aVmProduct)
        {
            return await _mediator.Send(new CreateProduct(aVmProduct));
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmProduct>> Put([FromBody] VmProduct aVmProduct,int id)
        {
            return await _mediator.Send(new UpdateProduct(aVmProduct,id));
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmProduct aVmProduct, int id)
        {
            var ddd =await _mediator.Send(new DeleteProduct( id));
            return Ok(1);
        }
    }
}
