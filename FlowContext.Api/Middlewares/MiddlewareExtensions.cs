namespace FlowContext.Api.Middlewares;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseGetFlowContext(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ContextMiddleware>();
    }
}