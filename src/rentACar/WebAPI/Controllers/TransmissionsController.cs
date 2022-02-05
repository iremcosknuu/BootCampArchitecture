using Application.Features.Transmissions.Commands.CreateTransmission;
using Application.Features.Transmissions.Commands.DeleteTransmisson;
using Application.Features.Transmissions.Commands.UpdateTransmission;
using Application.Features.Transmissions.Queries.GetTransmissionList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : BaseController
    {
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetTransmissionListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateTransmissionCommand createTransmissionCommand)
        {
            var result = await Mediator.Send(createTransmissionCommand);
            return Created("", result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateTransmissionCommand updateTransmissionCommand)
        {
            var result = await Mediator.Send(updateTransmissionCommand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteTransmissionCommand deleteTransmissionCommand)
        {
            var result = await Mediator.Send(deleteTransmissionCommand);
            return Ok(result);
        }
    }
}
