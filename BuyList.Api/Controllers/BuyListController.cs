using BuyList.Domain.Commands.BuyListCommands;
using BuyList.Domain.Commands.Responses;
using BuyList.Domain.Handlers;
using BuyList.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BuyList.Api.Controllers
{
    [ApiController]
    [Route("v1/buylist")]
    public class BuyListController : ControllerBase
    {
        public BuyListController()
        {
        }

        [Authorize]
        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateBuyListCommand command, [FromServices] BuyListHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("additem")]
        [HttpPost]
        public async Task<GenericCommandResult> AddItemListBuy([FromBody] AddItemBuyListCommand command, [FromServices] BuyListHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("removeitem")]
        [HttpPost]
        public async Task<GenericCommandResult> RemoveItemListBuy([FromBody] RemoveItemBuyListCommand command, [FromServices] BuyListHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IBuyListRepository buylistRepository)
        {
            string ownerId = Request.Query["ownerId"];

            if (ownerId == string.Empty || ownerId == null)
                return BadRequest(new { message = "O parametro ownerId é obrigatório!" });

            var result = await buylistRepository.Get(new Guid(ownerId));

            return Ok(result);
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateBuyListCommand command, [FromServices] BuyListHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpDelete]
        public async Task<GenericCommandResult> Delete([FromBody] DeleteBuyListCommand command, [FromServices] BuyListHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}