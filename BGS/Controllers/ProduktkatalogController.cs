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
    public class ProduktkatalogController : Controller
    {
        private BGSModel db;
        // create a Repository object
        // Skal placeres uden for ActionResult, da den gerne skal kunne bruges over det hele og fordi den er private

        // vi vil gerne have 8 produkter per side?
        public int SideStoerrelse = 8;

        // GET: Catalogue
        // indikerer hvilken kategori, der er valgt og hvilken side
        public ActionResult Produktkatalog(string kategori, int side = 1)
        {
            db = new BGSModel();

            // provides the view with details of the products to display on the page and details of pagination
            // if the category is not null, those Product objects with a matching Category property are selected
            ProduktListeViewModel model = new ProduktListeViewModel
            {
                Varer = db.Vare.Where(p => kategori == null || p.Kategori == kategori).OrderBy(p => p.Vareid).Skip((side - 1) * SideStoerrelse).Take(SideStoerrelse).ToList(), 

                SideopdelingsInfo = new SideopdelingsInfo
                {
                    NuvaerendeSide = side,
                    ElementerPerSide = SideStoerrelse,
                    // hvis der er valgt en kategori, så returneres antallet af items i den kategori
                    // hvis ikke, så returneres det totale antal produkter
                    // fjerner "side 2" når der ikke er nok produkter
                    TotaleElementer = kategori == null ? db.Vare.Count() : db.Vare.Where(e => e.Kategori == kategori).Count()
                },
                NuvaerendeKategori = kategori
            };            

            return View(model);
        }

        public ActionResult Produktvisning(string vareid)
        {
            ProduktVisModel model = new ProduktVisModel();
            Vare Vare = Depot.db.Vare.Where(p => p.Vareid == vareid).FirstOrDefault(); 

            if (Vare == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                model.vare = Vare;
                model.KoebsAntal = Depot.KoebsAntal;
            }
            
            return View(model);
        }
    }
}