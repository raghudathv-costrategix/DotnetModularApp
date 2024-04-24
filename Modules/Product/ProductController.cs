using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.Product
{
	[ApiController]
	[Route("api/products")]
	public class ProductController : ControllerBase
	{

		[HttpGet]
		public ActionResult GetProduct()
		{
			return Ok(new { ProductId = 1 });
		}
	}
}