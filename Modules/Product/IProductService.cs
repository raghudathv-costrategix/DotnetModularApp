using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.Product
{
	public interface IProductService
	{
		JsonResult GetProduct();
	}
}