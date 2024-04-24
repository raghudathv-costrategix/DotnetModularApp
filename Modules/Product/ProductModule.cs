namespace DotnetModularApp.Modules.Product
{
	public class ProductModule : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services)
		{
			return services;
		}
	}
}