using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Services;
using MySuperMarket.Models;

namespace MySuperMarket.Controllers
{
    public class EMPLOYEEsController : Controller
    {
        private MyMarket db = new MyMarket();

        // GET: EMPLOYEEs
        public ActionResult Index()
        {
            return View();
            //return Json(db.EMPLOYEE.ToList(),JsonRequestBehavior.AllowGet);
        }
        //[HttpPost]
        //[WebMethod]
        public JsonResult getJson()
        {
            //return Json(db.EMPLOYEE.ToList(), JsonRequestBehavior.AllowGet);
            //var list = db.EMPLOYEE.ToList();
            return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.ToList() });
            // return Json(new{ code=0, msg="", count=1000, data=new{ EMPLOYEE_ID = "5",EMPLOYEE_NAME = "a",SALARY = 1000,SEX = "man",PHONE_NUMBER = "111"}});
        }
        [HttpPost]
        public JsonResult search01(string id)
        {
            /*
            if (search_type.Equals("ID"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.EMPLOYEE_ID == value).ToList() }); ;
            }
            else if (search_type.Equals("姓名"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.EMPLOYEE_NAME == value).ToList() }); ;
            }
            else if (search_type.Equals("性别"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.SEX == value).ToList() }); ;
            }
            else if (search_type.Equals("手机号"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.PHONE_NUMBER == value).ToList() }); ;
            }
            else if (search_type.Equals("工资"))
            {
                return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.SALARY == long.Parse(value)).ToList() }); ;
            }
            */
            return Json(new { code = 0, msg = "", count = 1000, data = db.EMPLOYEE.Where(s => s.EMPLOYEE_ID == id).ToList() }); ;
        }

        // GET: EMPLOYEEs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLOYEEs/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMPLOYEE_ID,EMPLOYEE_NAME,SALARY,SEX,PHONE_NUMBER")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEE.Add(eMPLOYEE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMPLOYEE_ID,EMPLOYEE_NAME,SALARY,SEX,PHONE_NUMBER")] EMPLOYEE eMPLOYEE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEE);
        }

        // GET: EMPLOYEEs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            if (eMPLOYEE == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEE);
        }

        // POST: EMPLOYEEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EMPLOYEE eMPLOYEE = db.EMPLOYEE.Find(id);
            db.EMPLOYEE.Remove(eMPLOYEE);
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
