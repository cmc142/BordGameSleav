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
    public class StoerrelsesController : Controller
    {
        //private BGSModel db = new BGSModel();
        IStoerrelsesDepot db = new EFStoerrelseDepot();

        // GET: Admin/Stoerrelses
        public async Task<ActionResult> Index()
        {
            return View(await db.GetStoerrelse());
        }

        // GET: Admin/Stoerrelses/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stoerrelse stoerrelse = await db.GetStoerrelse(id ?? 0);

            if (stoerrelse == null)
            {
                return HttpNotFound();
            }
            return View(stoerrelse);

            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Stoerrelse stoerrelse = await db.Stoerrelse.FindAsync(id);
            //if (stoerrelse == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(stoerrelse);
        }

        // GET: Admin/Stoerrelses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Stoerrelses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Stoerrelseid,Bredde,Hoejde,StoerrelsesType")] Stoerrelse stoerrelse)
        {
            if (ModelState.IsValid)
            {
                //db.Stoerrelse.Add(stoerrelse);
                //await db.SaveChangesAsync();

                await db.SaveStoerrelse(stoerrelse);
                return RedirectToAction("Index");
            }

            return View(stoerrelse);
        }

        // GET: Admin/Stoerrelses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Stoerrelse stoerrelse = await db.GetStoerrelse(id??0);
            if (stoerrelse == null)
            {
                return HttpNotFound();
            }
            return View(stoerrelse);
        }

        // POST: Admin/Stoerrelses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Stoerrelseid,Bredde,Hoejde,StoerrelsesType")] Stoerrelse stoerrelse)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(stoerrelse).State = EntityState.Modified;
                //await db.SaveChangesAsync();

                await db.SaveStoerrelse(stoerrelse);
                return RedirectToAction("Index");
            }
            return View(stoerrelse);
        }

        // GET: Admin/Stoerrelses/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Stoerrelse stoerrelse = await db.GetStoerrelse(id??0);
            if (stoerrelse == null)
            {
                return HttpNotFound();
            }
            return View(stoerrelse);
        }

        // POST: Admin/Stoerrelses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            //Stoerrelse stoerrelse = await db.GetStoerrelse(id);
            //db.Stoerrelse.Remove(stoerrelse);
            //await db.SaveChangesAsync();
            try
            {
                await db.DeleteStoerrelse(id);
            }
            catch (Exception ex)
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
