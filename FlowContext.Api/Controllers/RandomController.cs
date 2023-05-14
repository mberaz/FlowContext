using FlowContext.Api.Helpers;
using FlowContext.Api.Services;
using Microsoft.AspNetCore.Mvc;

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
        public string Get()
        {
            var (contextFlowId, contextParentId, contextSpanId) = Flow.GetContext();

            _customLogger.Log("a test message");
            _randomService.DoAction();
            return $"flowID {contextFlowId}";
        }
    }
}