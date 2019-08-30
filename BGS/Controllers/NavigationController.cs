using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Controllers
{
    public class NavigationController : Controller
    {
        [ChildActionOnly]
        public PartialViewResult Menu()
        {
            return PartialView();
        }
    }
}