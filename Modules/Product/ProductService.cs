

using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.Product
{
	public class ProductService : IProductService
	{
		public JsonResult GetProduct()
		{
			return new JsonResult(new { productId = 1, status = "Success" });
		}
	}
}