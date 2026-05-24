using Microsoft.AspNetCore.Mvc;

namespace bai_tap_buoi_2.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Welcome to ASP.NET MVC";
        }

        public string About()
        {
            return "Nguyen Van Cuong";
        }

        public string Contact()
        {
            return "cuong@gmail.com";
        }
    }
}