using HRMaster.SharedKernel.Extensions.Pagging;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsHead.Command;
using Pos.Core.AccountsHead.Query;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
using Pos.Shared.Extensation.Result;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pos.BackEnd.Controllers
{
    [Route("api/AccountsHead")]
    [ApiController]
    public class AccountsHeadController : Controller
    {
        private readonly IMediator _mediator;
        public AccountsHeadController(IMediator mediator)
        {
            _mediator = mediator;

        }



        [HttpGet("{id}", Name = "GetByAccountsHeadId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHead>> GetByAccountsHeadId(int id)
        {
            return await _mediator.Send(new GetByAccountsHeadId(id));
        }
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsHead>> GetAll()
        {
            var gg = await _mediator.Send(new GetByAccountsHeadAll());
            return gg;
        }
        [Route("GetOnlyRoot")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsHead>> GetAllForParentDropdown()
        {
            var gg = await _mediator.Send(new GEtAccountsHeadOnlyParent());
            return gg;
        }
        [Route("GetOnlyChield")]
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IEnumerable<VmAccountsHead>> GetAllForChieldDropdown()
        {
            var gg = await _mediator.Send(new GetAccountHeadOnlyChiled());
            return gg;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHead>> Post([FromBody] VmAccountsHead aVmAccountsHead)
        {
            return await _mediator.Send(new CreateAccountsHead(aVmAccountsHead));
        }
        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<ActionResult<VmAccountsHead>> Put([FromBody] VmAccountsHead aVmAccountsHead, int id)
        {
            return await _mediator.Send(new UpdateAccountsHead(aVmAccountsHead, id));
        }
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(403)]
        public async Task<IActionResult> Delete(int id)
        {
            var ddd = await _mediator.Send(new DeleteAccountsHead(id));
            return Ok(1);
        }
    }
}
