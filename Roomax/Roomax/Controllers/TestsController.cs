using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Roomax.Controllers
{
    public class TestsController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            List<string> prenoms = new List<string>
            {
                "Gary", "Antoine", "Thomas",
            };
            return View(prenoms);
        }
    }
}