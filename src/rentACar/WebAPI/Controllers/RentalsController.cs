using Application.Features.Rentals.Commands.CreateRental;
using Application.Features.Rentals.Commands.DeleteRental;
using Application.Features.Rentals.Commands.UpdateRental;
using Application.Features.Rentals.Queries.GetRentalList;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : BaseController
    {

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll([FromQuery] PageRequest pageRequest)
        {
            var query = new GetRentalListQuery();
            query.PageRequest = pageRequest;
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateRentalCommand createRentalCommand)
        {
            var result = await Mediator.Send(createRentalCommand);
            return Created("",result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateRentalCommand updateRentalCoomand)
        {
            var result = await Mediator.Send(updateRentalCoomand);
            return Ok(result);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> delete([FromBody] DeleteRentalCommand deleteRentalCommand)
        {
            var result = await Mediator.Send(deleteRentalCommand);
            return Ok(result);
        }
    }
}
