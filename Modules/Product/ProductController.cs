using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.Product
{
	[ApiController]
	[Route("api/products")]
	public class ProductController(IProductService productService) : ControllerBase
	{
		private readonly IProductService productService = productService;

		[HttpGet]
		public JsonResult GetProduct()
		{
			return productService.GetProduct();
		}
	}
}