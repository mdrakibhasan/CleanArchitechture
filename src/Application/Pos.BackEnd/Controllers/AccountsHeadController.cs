﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Pos.Core.AccountsHead.Command;
using Pos.Core.Command;
using Pos.Core.Query;
using Pos.Service.Model;
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
            return await _mediator.Send(new GetByAccountsHeadAll());
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
