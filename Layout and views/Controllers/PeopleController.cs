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
            IEnumerable<Person> people;
            string filter = (string)this.Session["FilterString"];
            if (filter != null && filter != "") {
                bool caseSensitive = (bool)this.Session["FilterCaseSensitive"];
                people = PersonList.Filter(filter, caseSensitive, PersonList.people);
            }
            else
            {
                people = from person in PersonList.people
                         select person;
            }
            if(this.Session["SortByName"] != null)
            {
                people = PersonList.Sort((bool)this.Session["SortByName"], people);
            }
            return View(people);
        }

        public ActionResult Filter(string filterString, bool caseSensitive)
        {
            this.Session["FilterString"] = filterString;
            this.Session["FilterCaseSensitive"] = caseSensitive;
            return RedirectToAction("Index");
        }

        public ActionResult Sort(bool sortByName)
        {
            this.Session["SortByName"] = sortByName;
            return RedirectToAction("Index");
        }

        public ActionResult GenerateFragment()
    //Actions that modifies the list of people follows:

        [HttpPost]
        public ActionResult Add(string name, string city, string phone)
        {

            PersonList.AddPerson(new Person()
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