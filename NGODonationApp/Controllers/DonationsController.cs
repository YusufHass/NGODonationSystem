using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace NGODonationApp.Controllers
{
    public class DonationsController : Controller
    {
        IConfiguration _configuration;
        private string apiBaseUrl = "http://localhost:11039";

        public DonationsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
