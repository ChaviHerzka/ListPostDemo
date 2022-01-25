using ListPostDemo.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ListPostDemo.Data;

namespace ListPostDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString =
        @"Data Source=.\sqlexpress; Initial Catalog=OneToManyDemo;Integrated Security=true;";
        public IActionResult Index()
        {
            PeopleDb db = new(_connectionString);
            PeopleViewModel vm = new()
            {
                People = db.GetPeople()
            };
            if (TempData["message"] != null)
            {
                vm.Message = (string)TempData["message"];
            }
            return View(vm);
        }
        public IActionResult AddPeople()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddPeople(List<Person> people)
        {
            PeopleDb db = new(_connectionString);
            bool pplAdded = false;

            foreach (var person in people)
            {
                if (!string.IsNullOrEmpty(person.FirstName))
                {
                    db.AddPerson(person);
                    pplAdded = true;
                }
            }
            string message = pplAdded ? "People added successfully!" : "No people added";
            TempData["message"] = message;
            return Redirect("/home/Index");
        }
    }
}