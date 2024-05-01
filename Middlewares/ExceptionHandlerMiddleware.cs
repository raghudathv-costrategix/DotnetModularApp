using System.Net.Mime;
using System.Security.Authentication;

namespace DotnetModularApp.Middlewares
{
	public class CustomErrorResponse(int status, string message)
	{
		public int Status { get; set; } = status;

		public string Message { get; set; } = message;
	}

	public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger, IHostEnvironment environment) : IMiddleware
	{
		private readonly ILogger<ExceptionHandlerMiddleware> logger = logger;

		private readonly IHostEnvironment environment = environment;

		public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
		{
			httpContext.Response.ContentType = "application/json";

			try
			{
				await next(httpContext);
			}
			catch (Exception e)
			{
				logger.LogError(e, e.StackTrace?.ToString());

				await HandleExceptionAsync(httpContext, e);
			}
		}

		public async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
		{
			HttpResponse response = httpContext.Response;
			response.ContentType = MediaTypeNames.Application.Json;

			CustomErrorResponse errorResponse;

			response.StatusCode = exception switch
			{
				BadHttpRequestException => StatusCodes.Status400BadRequest,
				AuthenticationException => StatusCodes.Status401Unauthorized,
				ArgumentException => StatusCodes.Status404NotFound,
				_ => StatusCodes.Status500InternalServerError,
			};

			errorResponse = new CustomErrorResponse(response.StatusCode, exception.Message);

			await httpContext.Response.WriteAsJsonAsync(errorResponse);
		}

	}
}