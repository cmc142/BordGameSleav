using Boardgamesleeves.DAL;
using Boardgamesleeves.Models;
using Boardgamesleeves.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Boardgamesleeves.Controllers
{
    public class KurvController : Controller
    {
        IFakturaDepot repo = new EFFakturaDepot();

        public ViewResult Index(Kurv kurv)
        {
            KurvVisModel model = new KurvVisModel();
            
            model.Kurv = kurv;
            model.ReturnUrl = "/produktkatalog/produktkatalog/";
            model.KoebsAntal = Depot.KoebsAntal;
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(Kurv kurv, string Antal = "", string Vareid = "")
        {
            int antalInt;
            if(int.TryParse(Antal, out antalInt)) {
                KurvVare varefundet = kurv.KurvVareList.Find(x => x.Vare.Vareid.Equals(Vareid)) ?? new KurvVare();
                varefundet.Antal = antalInt;
            }

            return RedirectToAction("Index");
        }

        public PartialViewResult KurvDetaljer(Kurv kurv)
        {
            return PartialView(kurv);
        }

        public PartialViewResult VaretIKurv(Kurv kurv)
        {
            return PartialView(kurv.KurvVareList);
        }

        public ActionResult TjekUd(Kurv kurv)
        {
            ActionResult res = View(new TjekUdViewModel());
            if (kurv.KurvVareList.Count() == 0)
            {
              res= RedirectToAction("Index");
            }

            return res;
        }
        
        [HttpPost]
        public ViewResult TjekUd(Kurv kurv, TjekUdViewModel tjekUdViewModel)
        {
            if (kurv.KurvVareList.Count() == 0)
            {
                ModelState.AddModelError("", "Beklager, din kurv er tom. :(");
            }

            ViewResult res = View(tjekUdViewModel);

            if (ModelState.IsValid)
            {
                if (repo.SaveFaktura(kurv, tjekUdViewModel))
                {
                    ViewBag.KurvVare = new List<KurvVare>(kurv.KurvVareList);
                    ViewBag.KurvPris = kurv.TotalPris;

                    kurv.Clear();
                    ModelState.Clear();
                    res = View("Bekraeftelse");
                }
                else
                {
                    ModelState.AddModelError("", "Dit køb kunne ikke gennemføres. - prøv senere.");
                }
            }

            return res;
        }

        public ActionResult AddTilKurv(Kurv kurv,   
                                               string returnUrl = "", 
                                               string vareid = "",
                                               int? ValgtKoebsAntal = 0)
        {
            if (kurv != null)
            {
                Vare vare = repo.GetVare(vareid);

                if (vare != null)
                {
                    kurv.AddVare(vare, ValgtKoebsAntal ?? 0);

                }                
            }
            
            return RedirectToRoute("Default", new { Controller = "Produktkatalog", Action = "Produktkatalog" });
            //return RedirectToAction("Index", "Kurv",
            //                  new { returnUrl = returnUrl.Substring(1)});

        }


        public RedirectToRouteResult RemoveFraKurv(Kurv kurv,
                                                    string vareid = "",
                                                    string returnUrl = "")
        {
            if (kurv != null)
            {
                Vare vare = repo.GetVare(vareid);

                if (vare != null)
                {
                    kurv.RemoveVare(vare);
                }
            }
       
            return RedirectToAction("Index", "Kurv", new { returnUrl = returnUrl });
        }
    }
}