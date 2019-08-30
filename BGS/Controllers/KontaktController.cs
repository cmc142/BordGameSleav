using Boardgamesleeves.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Controllers
{
    public class KontaktController : Controller
    {
        // GET: Kontakt
        public ActionResult Kontakt()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendBeskedPreview(FormCollection formCollection, Kontaktformular kontakformular)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Navn = kontakformular.Navn;
                ViewBag.Email = kontakformular.Email;
                ViewBag.Emne = kontakformular.Emne;
                ViewBag.Besked = kontakformular.Besked;

                return View("SendBeskedPreview", kontakformular);

            } else
            {
                return View("Kontakt");
            }
        }
    }
}