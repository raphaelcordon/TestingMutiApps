using Microsoft.AspNetCore.Mvc;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
	public class UsersController : Controller
	{
		private UserApi _userApi;

        public UsersController(UserApi userApi)
        {
            _userApi = userApi;
        }

		[Route("User/DeleteUser/{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
        {
			_userApi.DeleteUser(id);
			return RedirectToAction("Index", "Home");
        }

		[Route("User/CreateUser")]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserApi user)
		{
			_userApi.CreateUser(user);
			return RedirectToAction("Index", "Home");
		}

		[Route("User/UpdateUser")]
		public async Task<IActionResult> UpdateUser([FromBody] UpdateUserApi user)
		{
			_userApi.UpdateUser(user);
			return RedirectToAction("Index", "Home");
		}
	}
}
