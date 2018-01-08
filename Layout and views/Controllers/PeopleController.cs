using Layout_and_views.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout_and_views.Controllers
{
    public class PeopleController : Controller
    {
        // GET: People
        [HttpGet]
        public ActionResult Index()
        {
            var model = new PersonList();
            return View(model);
        }
        // POST: People
        [HttpPost]
        public ActionResult Index(PersonList model)
        {
            model.Search();
            return View(model);
        }

        [HttpPost]
        public ActionResult Add(string name, string city, string phone)
        {
            var model = new PersonList();
            model.Persons.Add(new Person()
            {
                Name = name,
                City = city,
                PhoneNumber = phone,

            });
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            PersonList.Remove(id);
           
            return RedirectToAction("Index");
        }

    }
}