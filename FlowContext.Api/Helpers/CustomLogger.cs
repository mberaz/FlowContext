using System.Diagnostics;

namespace FlowContext.Api.Helpers
{
    public interface ICustomLogger
    {
        public void Log(string message);
    }
    public class CustomLogger : ICustomLogger
    {
        public void Log(string message)
        {
            var (contextFlowId, contextParentId, contextSpanId) = Flow.GetContext();
            Trace.WriteLine($"[{contextFlowId}] {message}");
        }
    }
}
