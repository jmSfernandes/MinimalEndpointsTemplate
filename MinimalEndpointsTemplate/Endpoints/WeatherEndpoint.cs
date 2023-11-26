using EndpointDefinitions;
using MinimalEndpointsTemplate.Services;

namespace MinimalEndpointsTemplate.Endpoints;

public class WeatherEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("/weatherData", GetWeatherData)
            .WithName("GetData").WithTags("Data");
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<IWeatherService, WeatherService>();
    }

    private async Task<IResult> GetWeatherData(IWeatherService weatherService)
    {
        return await weatherService.GetWeatherForecastAsync();
    }
}