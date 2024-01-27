using Microsoft.AspNetCore.Mvc;
using ToDoList.Database;

namespace ToDoList.Controllers.v1
{
	[ApiController]
	[Route("v1/users")]
	public class UserController(IDbProvider dbProvider) : Controller
	{
		private readonly IDbProvider _dbProvider = dbProvider;
	}
}
