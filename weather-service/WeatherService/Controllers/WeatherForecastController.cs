using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherService.CQRS.Query;

namespace WeatherService.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private IMediator mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
    {
        this.mediator = mediator;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await mediator.Send(new GetWeatherForecastQueryRequest { DateTime = DateTime.Now });
    }
}
