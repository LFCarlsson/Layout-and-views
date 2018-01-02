using Layout_and_views.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Layout_and_views.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to my page";
            return View();
        }

        
        public ActionResult About()
        {
            OwnerInfo ownerInfo = new OwnerInfo();
            ownerInfo.Id = 1;
            ownerInfo.Name = "Fredrik Carlsson";
            ownerInfo.Birthday = new DateTime(1989, 2, 8);
            ownerInfo.Age = (int)((DateTime.Now - ownerInfo.Birthday).Days / 365.25);
            ownerInfo.BirthPlace = "Kalmar";
            ownerInfo.City = "Nybro";
            ownerInfo.CVPath = "Files/"+ownerInfo.Id+"/cv.pdf";
            ViewBag.Message = "Your application description page.";

            return View(ownerInfo);
        }

        public ActionResult Contact()
        {
            OwnerInfo ownerInfo = new OwnerInfo();
            ownerInfo.City = "Nybro";
            ownerInfo.Adress = "Hantverkaregatan 21, 38244";
            ownerInfo.Phone = "076-1377534";
            ownerInfo.Email = "frecar89@gmail.com";

            return View(ownerInfo);
        }

        public ActionResult Projects()
        {
            ProjectList projectList = new ProjectList();
            projectList.Projects = new List<Project>();
            projectList.Projects.Add(new Project(
                "Arena Fighter",
                "A C# console game. Features saving and loading. Created as an exercise in object oriented programming. Part of the Lexicon ASP.net course",
                "https://github.com/LFCarlsson/Lexicon-Csharp-ArenaFighter",
                true));
            projectList.Projects.Add(new Project(
                "Vending Machine",
                "A C# program modelling a vending machine filled with products. Created as an exercise in polymorphism. Part of the Lexicon ASP.net course",
                "https://github.com/LFCarlsson/Lexicon-Csharp-VendingMachine",
                true));
            projectList.Projects.Add(new Project(
                "Blob Finder",
                "A simple c# program for 'coloring blobs' in a picture. Implemented using Disjoint sets and the union find algorithm",
                "https://github.com/LFCarlsson/BlobFinder",
                true));
            projectList.Projects.Add(new Project(
                "Calculator Generics",
                "A C# calculator that reads an expression, converts it to reversed Polish notation and finally calculates the result. It was created to test out C# delegates and generics",
                "https://github.com/LFCarlsson/Calculator-Generics",
                false));

            return View(projectList);
        }

        public FileResult Download(int id)
        {
            string FileVirtualPath = "~/Files/"+ id + "/cv.pdf";
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));
        }
    }
}