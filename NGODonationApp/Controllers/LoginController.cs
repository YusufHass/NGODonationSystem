/*using Microsoft.AspNetCore.Mvc;
using NGODonationApi.LoginRepository;
*//*using NGODonationApp.LoginRepository;
*//*using NGODonationApp.LoginRepository;
*//*
namespace NGODonationApp.Controllers
{
    
    public class LogedInController : Controller
    {
        private readonly ILogin _loginUser;
        public LogedInController(ILogin loginUser)
        {
            _loginUser = loginUser;
        }*//**//*
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string passcode)
        {
            var issuccess = _loginUser.AuthenticateUser(username, passcode);

            if (issuccess.Result != null)
            {
                ViewBag.username = string.Format("Successfully logged-in ", username);
                TempData["username"] = "Smith Robinson";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.username = string.Format("Login Failed ", username);
                return RedirectToAction("LoggedIn", "Login");
            }
            return View();
        }
    }
}
*/