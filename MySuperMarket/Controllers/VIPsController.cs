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
    public class VIPsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: VIPs
        public ActionResult Index()
        {
            var vIP = db.VIP.Include(v => v.EMPLOYEE);
            return View(vIP.ToList());
        }

        public JsonResult getJson()
        {
            return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.ToList() });
        }

        // GET: VIPs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIP vIP = db.VIP.Find(id);
            if (vIP == null)
            {
                return HttpNotFound();
            }
            return View(vIP);
        }

        // GET: VIPs/Create
        public ActionResult Create()
        {
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "EMPLOYEE_ID", "EMPLOYEE_NAME");
            return View();
        }

        // POST: VIPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VIP_ID,EMPLOYEE_ID,CREDITS,VIP_NAME,SEX,PHONE_NUMBER")] VIP vIP)
        {
            if (ModelState.IsValid)
            {
                db.VIP.Add(vIP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "EMPLOYEE_ID", "EMPLOYEE_NAME", vIP.EMPLOYEE_ID);
            return View(vIP);
        }

        // GET: VIPs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIP vIP = db.VIP.Find(id);
            if (vIP == null)
            {
                return HttpNotFound();
            }
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "EMPLOYEE_ID", "EMPLOYEE_NAME", vIP.EMPLOYEE_ID);
            return View(vIP);
        }

        // POST: VIPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VIP_ID,EMPLOYEE_ID,CREDITS,VIP_NAME,SEX,PHONE_NUMBER")] VIP vIP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vIP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EMPLOYEE_ID = new SelectList(db.EMPLOYEE, "EMPLOYEE_ID", "EMPLOYEE_NAME", vIP.EMPLOYEE_ID);
            return View(vIP);
        }

        // GET: VIPs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VIP vIP = db.VIP.Find(id);
            if (vIP == null)
            {
                return HttpNotFound();
            }
            return View(vIP);
        }

        // POST: VIPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            VIP vIP = db.VIP.Find(id);
            db.VIP.Remove(vIP);
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
