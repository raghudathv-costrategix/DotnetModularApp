using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DotnetModularApp.Modules.User
{
	public interface IUserService
	{
		JsonResult GetUser();
	}
}