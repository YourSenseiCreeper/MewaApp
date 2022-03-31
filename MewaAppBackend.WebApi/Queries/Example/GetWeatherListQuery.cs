using MediatR;

namespace MewaAppBackend.WebApi.Queries.Example
{
    public class GetWeatherListQuery: IRequest<IEnumerable<WeatherForecast>>
    {
    }
}
