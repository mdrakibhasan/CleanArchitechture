using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class SubCategoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSubcategory>> GetById(int id)
        {
            return await _mediator.Send(new GetBySubcategoryId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmSubcategory>> GetAll()
        {
            return await _mediator.Send(new GetBySubCategoryAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSubcategory>> Post([FromBody] VmSubcategory aVmSubcategory)
        {
            return await _mediator.Send(new CreateSubcategory(aVmSubcategory));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSubcategory>> Put([FromBody] VmSubcategory aVmSubcategory, int id)
        {
            return await _mediator.Send(new UpdateSubcategory(aVmSubcategory, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmSubcategory aVmSubcategory, int id)
        {
            //var ddd = await _mediator.Send(new DeleteSubcategory(id));
            return Ok(1);
        }
    }
}
