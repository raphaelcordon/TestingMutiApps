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

		[Route("User/UpdateUser/{id:int}")]
		public IActionResult UpdateUser(int id)
		{
			var user =  _userApi.UpdateUser(id);
			ViewData.Model = user;
			return View();
		}
		
		/*
		[Route("User/postUpdateUser")]
		public async Task<IActionResult> PostUpdateUser([FromBody] UpdateUserApi user)
		{
			_userApi.PostUpdateUser(user);
			return RedirectToAction("Index", "Home");
		}
		*/
	}
}
