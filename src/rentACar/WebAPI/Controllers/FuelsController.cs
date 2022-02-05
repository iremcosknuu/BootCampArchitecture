using Application.Features.Fuels.Commands.CreateFuel;
using Application.Features.Fuels.Commands.DeleteFuel;
using Application.Features.Fuels.Commands.UpdateFuel;
using Application.Features.Fuels.Queries.GetFuelList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetFuelListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateFuelCommand createFuelCommand)
        {
            var result = await Mediator.Send(createFuelCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateFuelCommand updateFuelCommand)
        {
            var result = await Mediator.Send(updateFuelCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteFuelCommand deleteFuelCommand)
        {
            var result = await Mediator.Send(deleteFuelCommand);
            return Ok(result);
        }
    }
}
