using Boardgamesleeves.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Controllers
{
    public class HomeController : Controller
    {
        // GET: Index
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}