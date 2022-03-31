using MediatR;
using MewaAppBackend.WebApi.Queries.Example;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MewaAppBackend.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExampleController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ExampleController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await _mediator.Send(new GetWeatherListQuery());
        }
    }
}
