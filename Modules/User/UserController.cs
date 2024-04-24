using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.User
{
	[ApiController]
	[Route("api/users")]
	public class UserController(IUserService userService) : ControllerBase
	{

		private readonly IUserService userService = userService;

		[HttpGet]
		public ActionResult GetUser()
		{
			return userService.GetUser();
		}
	}
}