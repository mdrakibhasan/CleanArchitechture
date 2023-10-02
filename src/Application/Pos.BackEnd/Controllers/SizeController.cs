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
    public class SizeController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SizeController(IMediator mediator)
        {
            _mediator = mediator;

        }


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSize>> GetById(int id)
        {
            return await _mediator.Send(new GetBySizeId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmSize>> GetAll()
        {
            return await _mediator.Send(new GetSizeAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSize>> Post([FromBody] VmSize aVmSize)
        {
            return await _mediator.Send(new CreateSize(aVmSize));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmSize>> Put([FromBody] VmSize aVmSize, int id)
        {
            return await _mediator.Send(new UpdateSize(aVmSize, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete([FromBody] VmSize aVmSize, int id)
        {
            //var ddd = await _mediator.Send(new DeleteSize(id));
            return Ok(1);
        }
    }
}
