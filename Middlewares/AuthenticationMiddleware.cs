using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Authentication;
using System.Security.Principal;

using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;

namespace DotnetModularApp.Middlewares
{
	public class AuthenticationMiddleware() : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			var endpoint = context.GetEndpoint();

			if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() is not object)
			{
				try
				{
					var token = context.Request.Headers.Authorization.FirstOrDefault("")?.Replace("Bearer ", "");
					var tokenHandler = new JwtSecurityTokenHandler();
					var validationParameters = new TokenValidationParameters
					{
						ValidateIssuer = false,
						ValidateAudience = false,
						RequireExpirationTime = false,
						ValidateLifetime = true,
						SignatureValidator = delegate (string token, TokenValidationParameters parameters)
						{
							var jwt = new JwtSecurityToken(token);
							return jwt;
						},
						RequireSignedTokens = false,
						ClockSkew = TimeSpan.Zero
					};

					var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);


					// set user to context
					context.User = new GenericPrincipal(new GenericIdentity(principal.Identity?.Name ?? ""), []);
				}
				catch (Exception e)
				{
					Console.WriteLine(e.ToString());
					context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
					throw new AuthenticationException("Unauthorized");
				}
			}

			await next(context);
		}
	}
}