using FlowContext.Api.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace FlowContext.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RandomController : ControllerBase
    {
        [HttpGet(Name = "")]
        public string Get()
        {
            var (contextFlowId, contextParentId, contextSpanId) = Flow.GetContext();

            return $"flowID {contextFlowId}";
        }
    }
}