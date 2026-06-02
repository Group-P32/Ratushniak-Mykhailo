using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JewelryStore.Models;

namespace Ratushniak_JewelryStore.Controllers
{
    public class JewelriesController : Controller
    {
        private JewelryContext db = new JewelryContext();

        // GET: Jewelries
        public ActionResult Index()
        {
            return View(db.Jewelries.ToList());
        }

        // GET: Jewelries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelry jewelry = db.Jewelries.Find(id);
            if (jewelry == null)
            {
                return HttpNotFound();
            }
            return View(jewelry);
        }

        // GET: Jewelries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jewelries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Type,Material,Weight,Price")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Jewelries.Add(jewelry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jewelry);
        }

        // GET: Jewelries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelry jewelry = db.Jewelries.Find(id);
            if (jewelry == null)
            {
                return HttpNotFound();
            }
            return View(jewelry);
        }

        // POST: Jewelries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Material,Weight,Price")] Jewelry jewelry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jewelry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jewelry);
        }

        // GET: Jewelries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jewelry jewelry = db.Jewelries.Find(id);
            if (jewelry == null)
            {
                return HttpNotFound();
            }
            return View(jewelry);
        }

        // POST: Jewelries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jewelry jewelry = db.Jewelries.Find(id);
            db.Jewelries.Remove(jewelry);
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
