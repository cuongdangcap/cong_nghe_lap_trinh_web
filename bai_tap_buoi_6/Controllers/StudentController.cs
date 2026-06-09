using Microsoft.AspNetCore.Mvc;
using bai_tap_buoi_6.Models;

namespace bai_tap_buoi_6.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                Name = "Nguyen Van A",
                Email = "a@gmail.com",
                Phone = "0123456789"
            },
            new Student
            {
                Id = 2,
                Name = "Tran Van B",
                Email = "b@gmail.com",
                Phone = "0987654321"
            }
        };

        public IActionResult Index()
        {
            return View(students);
        }

        public IActionResult Detail(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            student.Id = students.Max(x => x.Id) + 1;

            students.Add(student);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
                return View(student);

            var oldStudent =
                students.FirstOrDefault(x => x.Id == student.Id);

            if (oldStudent != null)
            {
                oldStudent.Name = student.Name;
                oldStudent.Email = student.Email;
                oldStudent.Phone = student.Phone;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student != null)
            {
                students.Remove(student);
            }

            return RedirectToAction("Index");
        }
    }
}