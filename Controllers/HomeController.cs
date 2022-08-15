using Microsoft.AspNetCore.Mvc;

namespace Tiffin.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult ContactUs()
        {
            return View();
        }
        public ViewResult About()
        {
            return View();
        }
    }
}
