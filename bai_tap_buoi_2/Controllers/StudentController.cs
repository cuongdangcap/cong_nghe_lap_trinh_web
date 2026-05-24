using Microsoft.AspNetCore.Mvc;
using bai_tap_buoi_2.Models;

namespace bai_tap_buoi_2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Info()
        {
            List<Student> ds = new List<Student>();

            ds.Add(new Student
            {
                Name = "Nguyen Van A",
                Age = 20,
                Major = "CNTT"
            });

            ds.Add(new Student
            {
                Name = "Tran Thi B",
                Age = 21,
                Major = "Marketing"
            });

            ds.Add(new Student
            {
                Name = "Le Van C",
                Age = 22,
                Major = "Ke Toan"
            });

            return View(ds);
        }
    }
}