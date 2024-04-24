namespace DotnetModularApp.Modules.Product
{
	public class UserModule : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services)
		{
			return services;
		}
	}
}