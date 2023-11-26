using MinimalEndpointsTemplate.Models;

namespace MinimalEndpointsTemplate.Services;

public interface IWeatherService
{
    public  Task<IResult> GetWeatherForecastAsync();
}