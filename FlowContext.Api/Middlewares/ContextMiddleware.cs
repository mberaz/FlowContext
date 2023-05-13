using FlowContext.Api.Helpers;

namespace FlowContext.Api.Middlewares;

public class ContextMiddleware
{
    private readonly RequestDelegate _next;

    public ContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.Headers.TryGetValue(Flow.FlowIdName, out var flowId);
        context.Request.Headers.TryGetValue(Flow.SpanIdName, out var spanId);

        Flow.SetContext(flowId, parentId: spanId);

        //Adds a delegate to be invoked just before response headers will be sent to the client.
        context.Response.OnStarting(state =>
        {
            //var (contextFlowId, contextParentId, contextSpanId) = Flow.GetContext();
            //context.Response.Headers.Add(Flow.FlowIdName, contextFlowId);
            //context.Response.Headers.Add(Flow.ParentIdName, contextParentId);
            //context.Response.Headers.Add(Flow.SpanIdName, contextSpanId);

             foreach (var item in Flow.GetContextAsDictionary())
             {
                 context.Response.Headers.Add(item.Key, item.Value);
             }
         
            return Task.CompletedTask;
        }, context);

        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}