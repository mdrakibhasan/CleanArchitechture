using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmCategory>> GetById(int id)
        {
            return await _mediator.Send(new GetByCategoryId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmCategory>> GetAll()
        {
            return await _mediator.Send(new GetByCategoryAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmCategory>> Post([FromBody] VmCategory aVmCategory)
        {
            return await _mediator.Send(new CreateCategory(aVmCategory));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmCategory>> Put([FromBody] VmCategory aVmCategory, int id)
        {
            return await _mediator.Send(new UpdateCategory(aVmCategory, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmCategory aVmCategory, int id)
        {
            //var ddd = await _mediator.Send(new DeleteCategory(id));
            return Ok(1);
        }
    }
}
