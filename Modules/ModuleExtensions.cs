namespace DotnetModularApp.Modules
{
	public static class ModuleExtensions
	{
		static readonly List<IModule> registeredModules = [];

		public static IServiceCollection RegisterModules(this IServiceCollection services)
		{
			var modules = DiscoverModules();

			foreach (var module in modules)
			{
				module.RegisterModule(services);
				registeredModules.Add(module);
			}

			return services;
		}

		private static IEnumerable<IModule> DiscoverModules()
		{
			return typeof(IModule).Assembly
					.GetTypes()
					.Where(p => p.IsClass && p.IsAssignableTo(typeof(IModule)))
					.Select(Activator.CreateInstance)
					.Cast<IModule>();
		}
	}
}