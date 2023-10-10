using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using NGODonationApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace NGODonationApp.Controllers
{

    public class DonorsController : Controller
    {
        IConfiguration _configuration;
        private string apiBaseUrl = "http://localhost:13225";          //   Assigned after using Get

        public DonorsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Donor> donorsList = new List<Donor>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:13225/api/Donors/Get"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    donorsList = JsonConvert.DeserializeObject<List<Donor>>(apiResponse);
                }
            }
            return View(donorsList);
        }

        public async Task<IActionResult> Details(int? id)
        {           
            Donor donor = new Donor();
            using (var httpClient = new HttpClient())
            {
                using (var responce = await httpClient.GetAsync("http://localhost:13225/api/Donors/Details/" + id))
                    if (responce.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await responce.Content.ReadAsStringAsync();
                        donor = JsonConvert.DeserializeObject<Donor>(apiResponse);
                    }
                    else
                    {
                        ViewBag.StatusCode = responce.StatusCode;
                    }
            }
            return View(donor);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Donor donor)
        {
            Donor insertDonor = new Donor();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("http://localhost:13225");
                var postTask = httpClient.PostAsJsonAsync<Donor>("/api/Donors/Create", donor);
                postTask.Wait();
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result;
                    ModelState.AddModelError(String.Empty, "Server Error.....Please Contact Administrator");

                }
            }
            return View(insertDonor);
        }
    }
}
