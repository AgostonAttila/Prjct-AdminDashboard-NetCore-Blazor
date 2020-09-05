using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Funds.Commands.CreateFund;
using Application.Features.Funds.Commands.DeleteFundById;
using Application.Features.Funds.Commands.UpdateFund;
using Application.Features.Funds.Queries.GetAllFunds;
using Application.Features.Funds.Queries.GetFundById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers.v1
{
    [ApiVersion("1.0")]
    public class FundController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFundsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllFundsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetFundByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateFundCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateFundCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteFundByIdCommand { Id = id }));
        }
    }
}
