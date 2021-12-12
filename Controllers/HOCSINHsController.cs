using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLyLopHoc_Nhom8.Models;
using PagedList;

namespace WebQuanLyLopHoc_Nhom8.Controllers
{
    public class HOCSINHsController : Controller
    {
        private QLLHModel db = new QLLHModel();

        // GET: HOCSINHs
        public ActionResult Index(string searchStr, int? page)
        {
            var hs = db.HOCSINHs.Include(h => h.LOPHOC);
            if (!String.IsNullOrEmpty(searchStr))
            {
                hs = hs.Where(e => e.TenHS.Contains(searchStr));
            }
            //Sắp xếp trước khi phân trang
            hs = hs.OrderBy(e => e.MaHS);
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(hs.ToPagedList(pageNumber, pageSize));
        }

        // GET: HOCSINHs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Create
        public ActionResult Create()
        {
            ViewBag.MaLH = new SelectList(db.LOPHOCs, "MaLH", "TenLH");
            return View();
        }

        // POST: HOCSINHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHS,TenHS,NgaySinh,GioiTinh,QueQuan,SDT,HinhAnh,MaLH")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.HOCSINHs.Add(hOCSINH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLH = new SelectList(db.LOPHOCs, "MaLH", "TenLH", hOCSINH.MaLH);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLH = new SelectList(db.LOPHOCs, "MaLH", "TenLH", hOCSINH.MaLH);
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHS,TenHS,NgaySinh,GioiTinh,QueQuan,SDT,HinhAnh,MaLH")] HOCSINH hOCSINH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCSINH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLH = new SelectList(db.LOPHOCs, "MaLH", "TenLH", hOCSINH.MaLH);
            return View(hOCSINH);
        }

        // GET: HOCSINHs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            if (hOCSINH == null)
            {
                return HttpNotFound();
            }
            return View(hOCSINH);
        }

        // POST: HOCSINHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HOCSINH hOCSINH = db.HOCSINHs.Find(id);
            db.HOCSINHs.Remove(hOCSINH);
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
