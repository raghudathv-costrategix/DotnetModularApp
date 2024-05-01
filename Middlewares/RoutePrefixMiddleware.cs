namespace DotnetModularApp.Middlewares
{
	public class RoutePrefixMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			context.Request.PathBase = "/api/v1";
			await next(context);
		}
	}
}