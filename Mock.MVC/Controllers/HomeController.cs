using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mock.Application.Features.Categories;
using Mock.Application.Features.Categories.Commands.CreateCategory;
using Mock.MVC.Models;
using Nancy.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

//01010124824

namespace Mock.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var response = GetApi("https://localhost:44308/api/Category/all");
            var rootobject = new JavaScriptSerializer().Deserialize<List<CategoryVM>>(response);
            return View(rootobject);
        }
        [HttpPost]
        public async Task<IActionResult> Privacy(CreateCategoryCommand category)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44308/api/Category");
                var response = await client.PostAsJsonAsync<CreateCategoryCommand>("Category", category);
                if (response.IsSuccessStatusCode) return RedirectToAction("Index");
                else return View();
            }
        }
        public static string GetApi(string ApiUrl)
        {
            var responseString = "";
            var request = (HttpWebRequest)WebRequest.Create(ApiUrl);
            request.Method = "GET";
            request.ContentType = "application/json";

            using (var response1 = request.GetResponse())
            {
                using (var reader = new StreamReader(response1.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }
            }
            return responseString;
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
