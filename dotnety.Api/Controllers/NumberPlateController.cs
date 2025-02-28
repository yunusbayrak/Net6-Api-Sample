using dotnety.Api.Helpers;
using dotnety.Api.SocketHubs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using dotnety.Application.Features.NumberPlates.Commands.SeedDb;
using dotnety.Application.Features.NumberPlates.Queries.GetById;
using dotnety.Application.Responses;

namespace dotnety.Api.Controllers
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
            var remoteAddress = Request.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "Unknown";

            if (numberPlate != null)
            {
                numberPlate.RemoteAddress = remoteAddress;
            }
            else
            {
                numberPlate = new GetNumberPlateResponse
                {
                    Id = id,
                    Name = "Plaka Kodu Bulunamadı",
                    RemoteAddress = remoteAddress
                };
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