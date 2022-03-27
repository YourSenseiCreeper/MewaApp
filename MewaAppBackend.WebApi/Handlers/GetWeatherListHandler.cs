using MediatR;
using MewaAppBackend.WebApi.Queries.Example;

namespace MewaAppBackend.WebApi.Handlers
{
    public class GetWeatherListHandler : IRequestHandler<GetWeatherListQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public GetWeatherListHandler()
        {

        }
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherListQuery request, CancellationToken cancellationToken)
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
             .ToArray();
        }
    }
}
