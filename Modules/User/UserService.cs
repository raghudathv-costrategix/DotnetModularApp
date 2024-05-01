using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.User
{
	public class UserService : IUserService
	{

		public JsonResult GetUser()
		{
			return new JsonResult(new { userId = 1, status = "Success" });
		}
	}
}