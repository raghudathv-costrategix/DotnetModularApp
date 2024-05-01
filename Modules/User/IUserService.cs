using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.User
{
	public interface IUserService
	{
		JsonResult GetUser();
	}
}