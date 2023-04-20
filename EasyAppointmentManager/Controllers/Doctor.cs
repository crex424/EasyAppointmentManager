using Microsoft.AspNetCore.Mvc;

namespace EasyAppointmentManager.Controllers
{
    public class Doctor : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
