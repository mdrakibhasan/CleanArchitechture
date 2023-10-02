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
    public class ColorController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ColorController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmColor>> GetById(int id)
        {
            return await _mediator.Send(new GetByColorId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmColor>> GetAll()
        {
            return await _mediator.Send(new GetByColorAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmColor>> Post([FromBody] VmColor aVmColor)
        {
            return await _mediator.Send(new CreateColor(aVmColor));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmColor>> Put([FromBody] VmColor aVmColor, int id)
        {
            return await _mediator.Send(new UpdateColor(aVmColor, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmColor aVmColor, int id)
        {
            //var ddd = await _mediator.Send(new DeleteColor(id));
            return Ok(1);
        }
    }
}
