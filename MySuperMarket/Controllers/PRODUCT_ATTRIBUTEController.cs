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
    public class PRODUCT_ATTRIBUTEController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: PRODUCT_ATTRIBUTE
        public ActionResult Index()
        {
            var pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Include(p => p.SUPPLIER);
            return View(pRODUCT_ATTRIBUTE.ToList());
        }

        public JsonResult getJson()
        {
            return Json(new { code = 0, msg = "", count = 1000, data = db.PRODUCT_ATTRIBUTE.ToList() });
        }

        // GET: PRODUCT_ATTRIBUTE/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(id);
            if (pRODUCT_ATTRIBUTE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_ATTRIBUTE);
        }

        // GET: PRODUCT_ATTRIBUTE/Create
        public ActionResult Create()
        {
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIER, "SUPPLIER_ID", "SUPPLIER_NAME");
            return View();
        }

        // POST: PRODUCT_ATTRIBUTE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRODUCT_ID,SUPPLIER_ID,PRODUCT_NAME,EXP,PURCHASE_PRICE,SELL_PRICE,TOTAL")] PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE)
        {
            if (ModelState.IsValid)
            {
                db.PRODUCT_ATTRIBUTE.Add(pRODUCT_ATTRIBUTE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIER, "SUPPLIER_ID", "SUPPLIER_NAME", pRODUCT_ATTRIBUTE.SUPPLIER_ID);
            return View(pRODUCT_ATTRIBUTE);
        }

        // GET: PRODUCT_ATTRIBUTE/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(id);
            if (pRODUCT_ATTRIBUTE == null)
            {
                return HttpNotFound();
            }
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIER, "SUPPLIER_ID", "SUPPLIER_NAME", pRODUCT_ATTRIBUTE.SUPPLIER_ID);
            return View(pRODUCT_ATTRIBUTE);
        }

        // POST: PRODUCT_ATTRIBUTE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRODUCT_ID,SUPPLIER_ID,PRODUCT_NAME,EXP,PURCHASE_PRICE,SELL_PRICE,TOTAL")] PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRODUCT_ATTRIBUTE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SUPPLIER_ID = new SelectList(db.SUPPLIER, "SUPPLIER_ID", "SUPPLIER_NAME", pRODUCT_ATTRIBUTE.SUPPLIER_ID);
            return View(pRODUCT_ATTRIBUTE);
        }

        // GET: PRODUCT_ATTRIBUTE/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(id);
            if (pRODUCT_ATTRIBUTE == null)
            {
                return HttpNotFound();
            }
            return View(pRODUCT_ATTRIBUTE);
        }

        // POST: PRODUCT_ATTRIBUTE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PRODUCT_ATTRIBUTE pRODUCT_ATTRIBUTE = db.PRODUCT_ATTRIBUTE.Find(id);
            db.PRODUCT_ATTRIBUTE.Remove(pRODUCT_ATTRIBUTE);
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
