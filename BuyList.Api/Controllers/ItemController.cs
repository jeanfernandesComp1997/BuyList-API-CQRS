using BuyList.Domain.Commands.ItemCommands;
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
    [Route("v1/items")]
    public class ItemController : ControllerBase
    {
        public ItemController() { }

        [Authorize]
        [Route("")]
        [HttpPost]
        public async Task<GenericCommandResult> Create([FromBody] CreateItemCommand command, [FromServices] ItemHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpGet]
        public async Task<IActionResult> Get([FromServices] IItemRepository itemRepository)
        {
            string ownerId = Request.Query["ownerId"];

            if (ownerId == string.Empty || ownerId == null)
                return BadRequest(new { message = "O parametro ownerId é obrigatório!" });

            var result = await itemRepository.Get(new Guid(ownerId));

            return Ok(result);
        }

        [Authorize]
        [Route("")]
        [HttpPut]
        public async Task<GenericCommandResult> Update([FromBody] UpdateItemCommand command, [FromServices] ItemHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }

        [Authorize]
        [Route("")]
        [HttpDelete]
        public async Task<GenericCommandResult> Delete([FromBody] DeleteItemCommand command, [FromServices] ItemHandler handler)
        {
            return (GenericCommandResult)await handler.Handle(command);
        }
    }
}