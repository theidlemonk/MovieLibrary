using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieLibrary.Controllers
{
    public class MovieController : Controller
    {

        public ActionResult Index()
        {
            return View("MovieHome");
        }

    }
}
