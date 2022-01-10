using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using UnluCoSample.Api.Helpers;
using UnluCoSample.Api.SocketHubs;
using UnluCoSample.Application.Commands;
using UnluCoSample.Application.Queries;
using UnluCoSample.Application.Responses;

namespace UnluCoSample.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class NumberPlateController : ControllerBase
    {
        private readonly IHubContext<LoggerHub> _logHub;
        private readonly IMediator _mediator;

        public NumberPlateController(IMediator mediator, IHubContext<LoggerHub> logHub)
        {
            _mediator = mediator;
            _logHub = logHub;
        }

        [HttpGet("{id}", Name = "GetNumberPlateById")]
        public async Task<IActionResult> Get(int id)
        {
            var numberPlate = await _mediator.Send(new GetNumberPlateByIdQuery(id));
            if (numberPlate != null)
                numberPlate.RemoteAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();
            else
            {
                numberPlate = new GetNumberPlateResponse() { Id = id, Name = "Plaka Kodu Bulunamadý", RemoteAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString() };
            }
            await _logHub.Clients.All.SendAsync("logs", JsonConvert.SerializeObject(numberPlate));
            return Ok(ApiResponseHelper.SuccessResponse(numberPlate));
        }

        [HttpGet("seed", Name = "SeedDatabase")]
        public async Task<IActionResult> SeedDatabase()
        {
            await _mediator.Send(new SeedDbCommand());
            return Ok(ApiResponseHelper.SuccessResponse());
        }
    }
}