using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
/*using NGODonationDataAccessLayer.Entity;
*/
using NGODonationApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagmentSystemUI.Controllers
{
    /*
     1.Add the Package Microsoft.ASPNET.WebApi.Client
    2. Add the package Newtonsoft.json
    3. Create Employees Controller
    4. Declare IConfiguration variable
    5. Inject it to the EmployeeController
    6. Create the instance of httpClient inside asction method index
    7. calling GetAsync methods with httpget Url
    6. Read the Content in form of string
    9. serializing it to the json formate
    serializing converting a string to a json format, Then client read it
     */
    public class UsersUIController : Controller
    {
        private IConfiguration configuration;
        //http://
        private string apiBaseUrl = "http://localhost:5047";
        public UsersUIController(IConfiguration configuration)
        {
            this.configuration = configuration;

        }
        public async Task<IActionResult> Index()
        {
            //employees coming from webapi will store here
            List<Users> employeesList = new List<Users>();
            //instance of creating httpclient
            using(var httpClients = new HttpClient())
            {
                //Here we need to pass the url we get from webApi and in thid case
                //the project name is ConsumingWebAPIByDotNetMVC and we need to
                //get the response which is the Get method response
                using (var response = await httpClients.GetAsync("http://localhost:13225/api/Users/Get"))
                {
                    //whatever the content we get will be stored here as a form of string
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    //Deserializing string from Json string into List Employee Object
                    employeesList = JsonConvert.DeserializeObject<List<Users>>(apiResponse);
                }

            }
            return View(employeesList);
        }

        //Display a particulare employee details

        public async Task<IActionResult> Details(int? id)
        {
            Users users = new Users();
            using (var httpClients = new HttpClient())
            {
                using(var response = await httpClients.GetAsync("http://localhost:13225/api/Users/Details/" + id))

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        users = JsonConvert.DeserializeObject<Users>(apiResponse);

                    }
                    else
                    {
                        ViewBag.StatusCode = response.StatusCode;
                    }

            }
            return View(users);

        }

        //Creating new employee

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Password,Email,Role")] Users insertUsers)
        {
            using (var httpClients = new HttpClient())
            {
                //different ways doing the above code without using
                httpClients.BaseAddress = new System.Uri("http://localhost:13225");
                var postTask = httpClients.PostAsJsonAsync<Users>("/api/Users/Create", insertUsers);
                postTask.Wait();
                //what we get above will stored in result
                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["Error"] = result;
                    ModelState.AddModelError(string.Empty, "Server Error....Please Contact Administrator");
                }
            }
            return View(insertUsers);

        }

        //updating/editing an existing empployee

        [HttpGet]
        public async Task<ActionResult>Edit(int? id)
        {
            var clientHttp = new HttpClient();
            //http response message getting from the url
            //  using (var response = await httpClients.GetAsync("http://localhost:13225/api/Users/Details/" + id))

            HttpResponseMessage message = await clientHttp.GetAsync("http://localhost:13225/api/Users/Details/" + id);
            if (message.IsSuccessStatusCode)
            {

                var responseData = message.Content.ReadAsStringAsync().Result;
                var users = JsonConvert.DeserializeObject<Users>(responseData);
                return View(users);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Users user)
        {
            // http://localhost:13225/api/Users/Edit
            using (var httpClients = new HttpClient())
            {
                HttpResponseMessage httpResponse = await httpClients.PutAsJsonAsync("http://localhost:13225/api/Users/Edit/"+id, user);
                if (httpResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Error");
                }
            }

        }

        [HttpGet]
        public async Task<ActionResult>Delete(int? id)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage message = await client.GetAsync("http://localhost:13225/api/Users/Details/" + id );
                if (message.IsSuccessStatusCode)
                {
                    var responseData = message.Content.ReadAsStringAsync().Result;
                    var user = JsonConvert.DeserializeObject<Users>(responseData);
                    return View(user);
                }
            }
            return View("Error");
        }
        [HttpPost]
        public async Task<ActionResult>Delete(int? id, Users users)
        {
            //http://localhost:13225/api/Users/Delete
            using (var client = new HttpClient())
            {
                HttpResponseMessage message = await client.DeleteAsync("http://localhost:13225/api/Users/Delete/" + id);
                if (!message.IsSuccessStatusCode)
                {
                    return RedirectToAction("Error");

                }
                return RedirectToAction("Index");

            }

        }


    }
}

