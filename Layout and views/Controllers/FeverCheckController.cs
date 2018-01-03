using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Layout_and_views.Models;

namespace Layout_and_views.Controllers
{
    public class FeverCheckController : Controller
    {
        // GET: FewerCheck
        public ActionResult FeverCheck()
        {
            return View(new FeverCheckController());
        }
    }
}