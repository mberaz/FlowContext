using FlowContext.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlowContext.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            var (contextFlowId, contextParentId, contextSpanId) = Flow.GetContext();

            return $"flowID {contextFlowId}";
        }
    }
}