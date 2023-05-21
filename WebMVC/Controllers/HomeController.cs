﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using WebMVC.Services;
using System.Net;
using System.Text;

namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        string baseUrl = "https://localhost:7148/api/";
        private UserApi _userApi;

        public HomeController(ILogger<HomeController> logger, UserApi userApi)
        {
            _logger = logger;
            _userApi = userApi;
        }

        public async Task<IActionResult> Index()
        {
            var users = await _userApi.GetAllUsers();

            ViewData.Model = users;
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