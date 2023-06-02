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

		public async Task<IActionResult> DeleteUser(int id)
        {
			await _userApi.DeleteUser(id);
			return RedirectToAction("Index", "Home");
        }

		[Route("Users/CreateUser")]
		public async Task<IActionResult> CreateUser([FromBody] CreateUserApi user)
		{
			await _userApi.CreateUser(user);
			return Json( new { redirectToUrl = Url.Action("Index", "Home") });
		}


		public async Task<IActionResult> UpdateUser(int id)
		{
			var user = await  _userApi.GetOneUser(id);
			ViewData.Model = user;
			return View();
		}

		public async Task<IActionResult> PostUpdateUser([FromBody] UpdateUserApi user)
		{
			await _userApi.UpdateUser(user);
			return Json(new { redirectToUrl = Url.Action("Index", "Home") });
		}
	}
}
