using System.Security.Claims;
using System.Security.Principal;
using DotnetModularApp.Middlewares;
using DotnetModularApp.Modules;

// -----------------
// APPLICATION BUILDER
// -----------------
var builder = WebApplication.CreateBuilder(args);
builder.Services.RegisterModules();
builder.Services.AddControllers();
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

builder.Services.AddScoped<AuthenticationMiddleware>();
builder.Services.AddTransient<RoutePrefixMiddleware>();
builder.Services.AddTransient<ExceptionHandlerMiddleware>();
builder.Services.AddTransient<RequestInterceptorMiddleware>();
builder.Services.AddTransient<IPrincipal>(provider =>
{
	var user = provider.GetService<IHttpContextAccessor>()?.HttpContext?.User;
	return user ?? new ClaimsPrincipal();
});

// cors
var AllowedOrigins = "_AllowedOrigins";
builder.Services.AddCors(options =>
{
	options.AddPolicy(name: AllowedOrigins, policy =>
	{
		policy.WithOrigins("*");
	});
});

// -----------------
// WEB APPLICATION
// -----------------
var app = builder.Build();
app.UseHttpsRedirection();

// Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
// 	app.UseSwagger();
// 	app.UseSwaggerUI();
// }

// enable static files
FileServerOptions fileServerOptions = new()
{
	StaticFileOptions = {
		DefaultContentType = "text/plain",
		ServeUnknownFileTypes = true,
	}
};

app.UseFileServer(fileServerOptions);

app.UseMiddleware<RoutePrefixMiddleware>();
app.UsePathBase(new PathString("/api/v1"));
app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseMiddleware<AuthenticationMiddleware>();
app.UseMiddleware<RequestInterceptorMiddleware>();
app.UseAuthorization();
app.MapControllers();
app.UseCors(AllowedOrigins);
app.Run();