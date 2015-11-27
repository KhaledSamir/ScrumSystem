using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MUMScrum.DataAccess;
using MUMScrum.Model;

namespace MUMScrum.Web.Controllers
{
    public class ProductBacklogs1Controller : Controller
    {
        private MUMScrumDbContext db = new MUMScrumDbContext();

        // GET: ProductBacklogs1
        public ActionResult Index()
        {
            return View(db.ProductBacklogs.ToList());
        }

        // GET: ProductBacklogs1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBacklog productBacklog = db.ProductBacklogs.Find(id);
            if (productBacklog == null)
            {
                return HttpNotFound();
            }
            return View(productBacklog);
        }

        // GET: ProductBacklogs1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductBacklogs1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,EmpId")] ProductBacklog productBacklog)
        {
            if (ModelState.IsValid)
            {
                db.ProductBacklogs.Add(productBacklog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productBacklog);
        }

        // GET: ProductBacklogs1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBacklog productBacklog = db.ProductBacklogs.Find(id);
            if (productBacklog == null)
            {
                return HttpNotFound();
            }
            return View(productBacklog);
        }

        // POST: ProductBacklogs1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,EmpId")] ProductBacklog productBacklog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productBacklog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productBacklog);
        }

        // GET: ProductBacklogs1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductBacklog productBacklog = db.ProductBacklogs.Find(id);
            if (productBacklog == null)
            {
                return HttpNotFound();
            }
            return View(productBacklog);
        }

        // POST: ProductBacklogs1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProductBacklog productBacklog = db.ProductBacklogs.Find(id);
            db.ProductBacklogs.Remove(productBacklog);
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
