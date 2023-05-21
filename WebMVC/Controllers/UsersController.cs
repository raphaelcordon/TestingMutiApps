using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using WebMVC.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
	public class UsersController : Controller
	{
		string baseUrl = "https://localhost:7148/api/";
		private UserApi _userApi;

        public UsersController(UserApi userApi)
        {
            _userApi = userApi;
        }

		[Route("User/DeleteUser/{id:int}")]
		public async Task<IActionResult> DeleteUser(int id)
        {
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(baseUrl + Convert.ToString(id));

				var response = await client.DeleteAsync("User");
			}
			return RedirectToAction("Index", "Home");
		
        }
    }
}
