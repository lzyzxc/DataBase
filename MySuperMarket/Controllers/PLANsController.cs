using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MySuperMarket.Models;

namespace MySuperMarket.Controllers
{
    public class PLANsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: PLANs
        public ActionResult Index()
        {
            var pLAN = db.PLAN.Include(p => p.PRODUCT_ATTRIBUTE);
            return View(pLAN.ToList());
        }
        public JsonResult getJson()
        {
            return Json(new { code = 0, msg = "", count = 1000, data = db.PLAN.ToList() });
        }

        // GET: PLANs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAN pLAN = db.PLAN.Find(id);
            if (pLAN == null)
            {
                return HttpNotFound();
            }
            return View(pLAN);
        }

        // GET: PLANs/Create
        public ActionResult Create()
        {
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_ATTRIBUTE, "PRODUCT_ID", "SUPPLIER_ID");
            return View();
        }

        // POST: PLANs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PLAN_ID,PRODUCT_ID,PLAN_NUM")] PLAN pLAN)
        {
            if (ModelState.IsValid)
            {
                db.PLAN.Add(pLAN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_ATTRIBUTE, "PRODUCT_ID", "SUPPLIER_ID", pLAN.PRODUCT_ID);
            return View(pLAN);
        }

        // GET: PLANs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAN pLAN = db.PLAN.Find(id);
            if (pLAN == null)
            {
                return HttpNotFound();
            }
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_ATTRIBUTE, "PRODUCT_ID", "SUPPLIER_ID", pLAN.PRODUCT_ID);
            return View(pLAN);
        }

        // POST: PLANs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PLAN_ID,PRODUCT_ID,PLAN_NUM")] PLAN pLAN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLAN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PRODUCT_ID = new SelectList(db.PRODUCT_ATTRIBUTE, "PRODUCT_ID", "SUPPLIER_ID", pLAN.PRODUCT_ID);
            return View(pLAN);
        }

        // GET: PLANs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAN pLAN = db.PLAN.Find(id);
            if (pLAN == null)
            {
                return HttpNotFound();
            }
            return View(pLAN);
        }

        // POST: PLANs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PLAN pLAN = db.PLAN.Find(id);
            db.PLAN.Remove(pLAN);
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
