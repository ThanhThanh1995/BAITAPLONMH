using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BaiTap.Models;

namespace BaiTap.Controllers
{
    public class bo_cau_hoiController : Controller
    {
        private baitaplonmhEntities db = new baitaplonmhEntities();

        // GET: bo_cau_hoi
        public ActionResult Index()
        {
            return View(db.bo_cau_hoi.ToList());
        }

        // GET: bo_cau_hoi/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bo_cau_hoi bo_cau_hoi = db.bo_cau_hoi.Find(id);
            if (bo_cau_hoi == null)
            {
                return HttpNotFound();
            }
            return View(bo_cau_hoi);
        }

        // GET: bo_cau_hoi/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: bo_cau_hoi/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_bo_cau_hoi,Picture")] bo_cau_hoi bo_cau_hoi)
        {
            if (ModelState.IsValid)
            {
                db.bo_cau_hoi.Add(bo_cau_hoi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bo_cau_hoi);
        }

        // GET: bo_cau_hoi/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bo_cau_hoi bo_cau_hoi = db.bo_cau_hoi.Find(id);
            if (bo_cau_hoi == null)
            {
                return HttpNotFound();
            }
            return View(bo_cau_hoi);
        }

        // POST: bo_cau_hoi/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_bo_cau_hoi,Picture")] bo_cau_hoi bo_cau_hoi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bo_cau_hoi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bo_cau_hoi);
        }

        // GET: bo_cau_hoi/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            bo_cau_hoi bo_cau_hoi = db.bo_cau_hoi.Find(id);
            if (bo_cau_hoi == null)
            {
                return HttpNotFound();
            }
            return View(bo_cau_hoi);
        }

        // POST: bo_cau_hoi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            bo_cau_hoi bo_cau_hoi = db.bo_cau_hoi.Find(id);
            db.bo_cau_hoi.Remove(bo_cau_hoi);
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
