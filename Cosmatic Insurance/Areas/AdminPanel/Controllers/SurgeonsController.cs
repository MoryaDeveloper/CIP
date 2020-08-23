using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cosmatic_Insurance.Data;
using Cosmatic_Insurance.Models;

namespace Cosmatic_Insurance.Areas.AdminPanel.Controllers
{
    public class SurgeonsController : Controller
    {
        private CosmaticDbContext db = new CosmaticDbContext();

        // GET: AdminPanel/Surgeons
        public ActionResult Index()
        {
            return View(db.Surgeons.ToList());
        }

        // GET: AdminPanel/Surgeons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            return View(surgeon);
        }

        // GET: AdminPanel/Surgeons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Surgeons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,MobileNo,Email,Password,Address,Specialization")] Surgeon surgeon)
        {
            if (ModelState.IsValid)
            {
                db.Surgeons.Add(surgeon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(surgeon);
        }

        // GET: AdminPanel/Surgeons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            return View(surgeon);
        }

        // POST: AdminPanel/Surgeons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,MobileNo,Email,Password,Address,Specialization")] Surgeon surgeon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(surgeon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(surgeon);
        }

        // GET: AdminPanel/Surgeons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Surgeon surgeon = db.Surgeons.Find(id);
            if (surgeon == null)
            {
                return HttpNotFound();
            }
            return View(surgeon);
        }

        // POST: AdminPanel/Surgeons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Surgeon surgeon = db.Surgeons.Find(id);
            db.Surgeons.Remove(surgeon);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
