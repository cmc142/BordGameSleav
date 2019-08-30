using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Boardgamesleeves.DAL;
using Boardgamesleeves.Models;
using Boardgamesleeves.Areas.Admin.DALAdmin;

namespace Boardgamesleeves.Areas.Admin.Controllers
{
    public class VaresController : Controller
    {
       // private BGSModel db = new BGSModel();
        IVareDepot db = new EFVareDepot();

        public async Task<ActionResult> Index()
        {
            return View(await db.GetVareList());
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Vare vare = await db.GetVare(id??"");
            if (vare == null)
            {
                return HttpNotFound();
            }
            return View(vare);
        }

        public async Task<ActionResult> Create()
        {
            ViewBag.Stoerrelseid = new SelectList(await db.GetStoerrelsesList(), "Stoerrelseid", "StoerrelsesType");
            return View();
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Vareid,Titel,Oprettelsesdato,Pris,Kategori,Beskrivelse,Billedsti,LagerAntal,STK,Stoerrelseid")] Vare vare)
        {
            if (ModelState.IsValid)
            {
                //db.Vare.Add(vare);
                //await db.SaveChangesAsync();
                
                await db.CreateVare(vare);
                return RedirectToAction("Index");
            }

            ViewBag.Stoerrelseid = new SelectList(await db.GetStoerrelsesList(), "Stoerrelseid", "StoerrelsesType", vare.Stoerrelseid);
            return View(vare);
        }

        // GET: Admin/Vares/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vare vare = await db.GetVare(id??""); //db.Vare.FindAsync(id);
            if (vare == null)
            {
                return HttpNotFound();
            }
            ViewBag.Stoerrelseid = new SelectList(await db.GetStoerrelsesList(), "Stoerrelseid", "StoerrelsesType", vare.Stoerrelseid);
            return View(vare);
        }

        // POST: Admin/Vares/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Vareid,Titel,Oprettelsesdato,Pris,Kategori,Beskrivelse,Billedsti,LagerAntal,STK,Stoerrelseid")] Vare vare)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(vare).State = EntityState.Modified;
                //await db.SaveChangesAsync();
                await db.EditVare(vare);
                return RedirectToAction("Index");
            }
            ViewBag.Stoerrelseid = new SelectList(await db.GetStoerrelsesList(), "Stoerrelseid", "StoerrelsesType", vare.Stoerrelseid);
            return View(vare);
        }

        // GET: Admin/Vares/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vare vare = await db.GetVare(id ??""); //db.Vare.FindAsync(id);
            if (vare == null)
            {
                return HttpNotFound();
            }
            return View(vare);
        }

        // POST: Admin/Vares/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            //Vare vare = await db.Vare.FindAsync(id);
            //db.Vare.Remove(vare);
            //await db.SaveChangesAsync();
            try
            {
                await db.DeleteVare(id);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }

            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
