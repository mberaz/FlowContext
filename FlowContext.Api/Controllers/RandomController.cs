using FlowContext.Api.Helpers;
using FlowContext.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace FlowContext.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomController : ControllerBase
    {
        private readonly ICustomLogger _customLogger;
        private readonly IRandomService _randomService;

        public RandomController(ICustomLogger customLogger, IRandomService randomService)
        {
            _customLogger = customLogger;
            _randomService = randomService;
        }

        [HttpGet(Name = "")]
        public async Task<string> Get()
        {
            _customLogger.Log("a test message");
            await _randomService.DoAction();

            await HttpUtils.Get<JObject>("https://api.chucknorris.io/jokes/random");

            var (contextFlowId, _, _) = Flow.GetContext();

            return $"flowID {contextFlowId}";
        }
    }
}