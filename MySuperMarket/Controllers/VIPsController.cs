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
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
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
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
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

        public JsonResult getJson()
        {
            //return Json(db.EMPLOYEE.ToList(), JsonRequestBehavior.AllowGet);
            return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.ToList() });
            // return Json(new{ code=0, msg="", count=1000, data=new{ EMPLOYEE_ID = "5",EMPLOYEE_NAME = "a",SALARY = 1000,SEX = "man",PHONE_NUMBER = "111"}});
        }
        [HttpPost]
        public JsonResult search01(string type, string id)
        {
            string searchString = id;
            if (type.Equals("1"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.VIP_ID == searchString).ToList() }); ;
            }
            else if (type.Equals("2"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.VIP_NAME == searchString).ToList() }); ;
            }
            else if (type.Equals("3"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.SEX == searchString).ToList() }); ;
            }
            else if (type.Equals("4"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.PHONE_NUMBER == searchString).ToList() }); ;
            }
            else if (type.Equals("5"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.CREDITS == long.Parse(searchString)).ToList() }); ;
            }
            else if (type.Equals("6"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.VIP.Where(s => s.EMPLOYEE_ID == searchString).ToList() }); ;
            }
            else
            {
                return null;
            }

        }
    }
}
