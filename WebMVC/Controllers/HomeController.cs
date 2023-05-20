using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseUrl = "https://localhost:7148";
        private UserApi _userApi;

        public HomeController(ILogger<HomeController> logger, UserApi userApi)
        {
            _logger = logger;
            _userApi = userApi;
        }

        public async Task<IActionResult> Index()
        {
			/*
            IList<ReadUserFromApi> user = new List<ReadUserFromApi>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage getData = await client.GetAsync("User");

                if (getData.IsSuccessStatusCode)
                {
                    string results = getData.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<List<ReadUserFromApi>>(results);
                }
                else
                {
                    Console.WriteLine("Error calling web Api");
                }

                ViewData.Model = user;
            }
            */
			ViewData.Model = await _userApi.GetAllUsers();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}