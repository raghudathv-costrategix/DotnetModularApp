namespace DotnetModularApp.Modules.Product
{
	public class ProductModule : IModule
	{
		public IServiceCollection RegisterModule(IServiceCollection services)
		{
			services.AddScoped<IProductService, ProductService>();
			return services;
		}
	}
}