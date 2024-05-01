using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.Product
{
	[ApiController, Route("products")]
	public class ProductController(IProductService productService) : ControllerBase
	{
		private readonly IProductService productService = productService;

		[HttpGet]
		public JsonResult GetProducts()
		{
			return productService.GetProduct();
		}

		[HttpGet, Route("{productId}")]
		public JsonResult GetProductById(int id)
		{
			return new JsonResult(new
			{

			});
		}
	}
}