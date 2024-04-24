using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.User
{
	[ApiController]
	[Route("api/users")]
	public class UserController : ControllerBase
	{

		[HttpGet]
		public ActionResult GetUser()
		{
			return Ok(new { UserId = 1 });
		}
	}
}