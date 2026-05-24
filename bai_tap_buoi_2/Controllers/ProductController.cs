using Microsoft.AspNetCore.Mvc;

namespace bai_tap_buoi_2.Controllers
{
    public class ProductController : Controller
    {
        public string Detail(int id)
        {
            return "Product ID = " + id;
        }

        public string Category(string name)
        {
            return "Category = " + name;
        }
    }
}