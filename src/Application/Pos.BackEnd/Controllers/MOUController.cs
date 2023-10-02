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
    public class MOUController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MOUController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmMOU>> GetById(int id)
        {
            return await _mediator.Send(new GetByMOUId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmMOU>> GetAll()
        {
            return await _mediator.Send(new GetByMOUAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmMOU>> Post([FromBody] VmMOU aVmMOU)
        {
            return await _mediator.Send(new CreateMOU(aVmMOU));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmMOU>> Put([FromBody] VmMOU aVmMOU, int id)
        {
            return await _mediator.Send(new UpdateMOU(aVmMOU, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmMOU aVmMOU, int id)
        {
            //var ddd = await _mediator.Send(new DeleteMOU(id));
            return Ok(1);
        }
    }
}
