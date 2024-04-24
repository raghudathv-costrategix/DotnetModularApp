namespace DotnetModularApp.Modules
{
	public interface IModule
	{
		IServiceCollection RegisterModule(IServiceCollection services);
	}
}