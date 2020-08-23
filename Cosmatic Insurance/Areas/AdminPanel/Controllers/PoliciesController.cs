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
    public class PoliciesController : Controller
    {
        private CosmaticDbContext db = new CosmaticDbContext();

        // GET: AdminPanel/Policies
        public ActionResult Index()
        {
            return View(db.Policys.ToList());
        }

        // GET: AdminPanel/Policies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policys.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: AdminPanel/Policies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PolicyName,PolicyDescription,Amount,EMI,PolicyCompanyName")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Policys.Add(policy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: AdminPanel/Policies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policys.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: AdminPanel/Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PolicyName,PolicyDescription,Amount,EMI,PolicyCompanyName")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(policy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(policy);
        }

        // GET: AdminPanel/Policies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Policy policy = db.Policys.Find(id);
            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: AdminPanel/Policies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Policy policy = db.Policys.Find(id);
            db.Policys.Remove(policy);
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
