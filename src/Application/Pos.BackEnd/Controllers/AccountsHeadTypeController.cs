using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsHeadType.Command;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    public class AccountsHeadTypeController : Controller
    {
        private readonly IMediator _mediator;
        public AccountsHeadTypeController(IMediator mediator)
        {
            _mediator = mediator;

        }


        
        [HttpGet("[action]/{id}", Name = "GetById")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> GetById(int id)
        {
            return await _mediator.Send(new GetByAccountsHeadTypeId(id));
        }
        [HttpGet]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsHeadType>> GetAll()
        {
            return await _mediator.Send(new GetByAccountsHeadTypeAll());
        }
        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> Post([FromBody] VmAccountsHeadType aVmAccountsHeadType)
        {
            return await _mediator.Send(new CreateAccountsHeadType(aVmAccountsHeadType));
        }
        [HttpPut]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHeadType>> Put([FromBody] VmAccountsHeadType aVmAccountsHeadType, int id)
        {
            return await _mediator.Send(new UpdateAccountsHeadType(aVmAccountsHeadType, id));
        }
        [HttpDelete]
        [Route("[action]")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete( int id)
        {
            var ddd = await _mediator.Send(new DeleteAccountsHeadType(id));
            return Ok(1);
        }
    }
}
