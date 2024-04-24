using DotnetModularApp.Modules.User;

namespace DotnetModularApp.Modules.Product
{
	public class UserModule : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services)
		{
			services.AddScoped<IUserService, UserService>();
			return services;
		}
	}
}