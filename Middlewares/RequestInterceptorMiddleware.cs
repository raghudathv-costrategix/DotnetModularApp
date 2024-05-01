using System.Security.Principal;

using Microsoft.Extensions.Primitives;

namespace DotnetModularApp.Middlewares
{
	public class RequestInterceptorMiddleware : IMiddleware
	{
		private readonly ILogger<RequestInterceptorMiddleware> logger;

		public RequestInterceptorMiddleware(
				ILogger<RequestInterceptorMiddleware> logger,
				IPrincipal principal
		)
		{
			this.logger = logger;
		}

		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			HttpRequest request = context.Request;
			RouteValueDictionary routeValues = request.RouteValues;
			IHeaderDictionary headers = request.Headers;

			logger.LogInformation(string.Join(",", routeValues.ToDictionary()));
			logger.LogInformation(string.Join(",", headers.ToDictionary()));

			await next(context);
		}
	}
}