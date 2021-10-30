using Consul.Demo.Helpers;
using Consul.Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Consul.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get()
    {
        var consulDemoKey = await ConsulKeyValueProvider.GetValueAsync<ConsulDemoKey>(key: "ConsulDemoKey");

        if(consulDemoKey != null && consulDemoKey.IsEnabled)
        {
            return Ok(consulDemoKey);
        }

        return Ok("ConsulDemoKey is null");
    }
}
