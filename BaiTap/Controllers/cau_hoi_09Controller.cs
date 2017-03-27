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
    public class cau_hoi_09Controller : Controller
    {
        private baitaplonmhEntities db = new baitaplonmhEntities();
        public ActionResult ShowProduct_9(int? page)
        {
            //khai báo kích thước của trang
            int pagesize = 1;
            //Lấy ra tất cả các bản ghi có trong cơ sở dữ liệu
            var products = db.cau_hoi_09.AsEnumerable();
            //Tính tổng số bản ghi 
            var CountProducts = products.Count();
            //Tính số trang cần được hiển thi lên web
            var CountPages = (CountProducts % pagesize == 0) ? CountProducts / pagesize : (CountProducts / pagesize) + 1;
            //Nếu không chọn số trang thì mặc địnhlà trang 1
            if (page == null)
            {
                page = 1;
            }
            //Nếu không:

            //đưa tống số trang ra vieww
            ViewBag.CountProducts = CountProducts;
            //Đưa giá trị của trang ra vieww
            ViewBag.page = page;
            //Chon đúng số trang cần chọn thì phải bỏ qua các trang trước của nó
            var kq = db.cau_hoi_09.OrderBy(p => p.Ma_cau_hoi).Skip((page.Value - 1) * pagesize).Take(pagesize);
            //Trả về  giá trị
            return View(kq);
        }
        // GET: cau_hoi_09
        public ActionResult Index()
        {
            var cau_hoi_09 = db.cau_hoi_09.Include(c => c.bo_cau_hoi);
            return View(cau_hoi_09.ToList());
        }

        // GET: cau_hoi_09/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cau_hoi_09 cau_hoi_09 = db.cau_hoi_09.Find(id);
            if (cau_hoi_09 == null)
            {
                return HttpNotFound();
            }
            return View(cau_hoi_09);
        }

        // GET: cau_hoi_09/Create
        public ActionResult Create()
        {
            ViewBag.Ma_bo_cau_hoi = new SelectList(db.bo_cau_hoi, "Ma_bo_cau_hoi", "Picture");
            return View();
        }

        // POST: cau_hoi_09/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Ma_cau_hoi,Ma_bo_cau_hoi,Noi_Dung,Dap_An_A,Dap_An_B,Dap_An_C,Dap_An_D,Dap_An_Dung")] cau_hoi_09 cau_hoi_09)
        {
            if (ModelState.IsValid)
            {
                db.cau_hoi_09.Add(cau_hoi_09);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Ma_bo_cau_hoi = new SelectList(db.bo_cau_hoi, "Ma_bo_cau_hoi", "Picture", cau_hoi_09.Ma_bo_cau_hoi);
            return View(cau_hoi_09);
        }

        // GET: cau_hoi_09/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cau_hoi_09 cau_hoi_09 = db.cau_hoi_09.Find(id);
            if (cau_hoi_09 == null)
            {
                return HttpNotFound();
            }
            ViewBag.Ma_bo_cau_hoi = new SelectList(db.bo_cau_hoi, "Ma_bo_cau_hoi", "Picture", cau_hoi_09.Ma_bo_cau_hoi);
            return View(cau_hoi_09);
        }

        // POST: cau_hoi_09/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Ma_cau_hoi,Ma_bo_cau_hoi,Noi_Dung,Dap_An_A,Dap_An_B,Dap_An_C,Dap_An_D,Dap_An_Dung")] cau_hoi_09 cau_hoi_09)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cau_hoi_09).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Ma_bo_cau_hoi = new SelectList(db.bo_cau_hoi, "Ma_bo_cau_hoi", "Picture", cau_hoi_09.Ma_bo_cau_hoi);
            return View(cau_hoi_09);
        }

        // GET: cau_hoi_09/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            cau_hoi_09 cau_hoi_09 = db.cau_hoi_09.Find(id);
            if (cau_hoi_09 == null)
            {
                return HttpNotFound();
            }
            return View(cau_hoi_09);
        }

        // POST: cau_hoi_09/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            cau_hoi_09 cau_hoi_09 = db.cau_hoi_09.Find(id);
            db.cau_hoi_09.Remove(cau_hoi_09);
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
