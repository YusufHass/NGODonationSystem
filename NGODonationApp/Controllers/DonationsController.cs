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
    public class DonationsController : Controller
    {
        IConfiguration _configuration;
        private string apiBaseUrl = "http://localhost:13225";

        public DonationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IActionResult> Index()
        {
            List<Donation> donationList = new List<Donation>();

            using(var httpClient = new HttpClient()) 
            {
                using (var response = await httpClient.GetAsync("http://localhost:13225/api/Donations/Get"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    donationList = JsonConvert.DeserializeObject<List<Donation>>(apiResponse,

                            new JsonSerializerSettings
                            {
                                NullValueHandling = NullValueHandling.Ignore
                            });
                    //donationList = apiResponse.to
                }
            }

            return View(donationList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Donation donation)
        {
            Donation insertDonation = new Donation();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new System.Uri("http://localhost:13225");
                var postTask = httpClient.PostAsJsonAsync<Donation>("/api/Donations/Create", donation);
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
            return View(insertDonation);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var client = new HttpClient();
            HttpResponseMessage responseMessage = await client.GetAsync("http://localhost:13225/api/Donations/Edit/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                var Donation = JsonConvert.DeserializeObject<Donation>(responseData);

                return View(Donation);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Donation donation)
        {
            using (var client = new HttpClient())
            {

                HttpResponseMessage responseMessage = await client.PutAsJsonAsync("http://localhost:13225/api/Donations/Edit/" + id, donation);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            return RedirectToAction("Error");
        }
    }
}
