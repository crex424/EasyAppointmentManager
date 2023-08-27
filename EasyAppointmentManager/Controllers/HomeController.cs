using EasyAppointmentManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EasyAppointmentManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;
        private readonly IEmailProvider _emailProvider;

        public HomeController(ILogger<HomeController> logger, IConfiguration config, IEmailProvider emailProvider)
        {
            _logger = logger;
            _config = config;
            _emailProvider = emailProvider;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.apiKey = _config["VisualCrossingPublicKey"];
            await _emailProvider.SendEmailAsync(null, null, null, null, null);
            return View();
        }

        // [Authorize]
        // [Authorize(Roles = IdentityHelper.Employee)]
        // [AllowAnonymous]
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