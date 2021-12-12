using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebQuanLyLopHoc_Nhom8.Models;

namespace WebQuanLyLopHoc_Nhom8.Controllers
{
    public class HOCPHIsController : Controller
    {
        private QLLHModel db = new QLLHModel();

        // GET: HOCPHIs
        public ActionResult Index()
        {
            var hOCPHIs = db.HOCPHIs.Include(h => h.HOCSINH);
            return View(hOCPHIs.ToList());
        }

        // GET: HOCPHIs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCPHI hOCPHI = db.HOCPHIs.Find(id);
            if (hOCPHI == null)
            {
                return HttpNotFound();
            }
            return View(hOCPHI);
        }

        // GET: HOCPHIs/Create
        public ActionResult Create()
        {
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS");
            return View();
        }

        // POST: HOCPHIs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaHocPHi,MaHS,HocPhi1,NgayDong,TinhTrang,GhiChu")] HOCPHI hOCPHI)
        {
            if (ModelState.IsValid)
            {
                db.HOCPHIs.Add(hOCPHI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", hOCPHI.MaHS);
            return View(hOCPHI);
        }

        // GET: HOCPHIs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCPHI hOCPHI = db.HOCPHIs.Find(id);
            if (hOCPHI == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", hOCPHI.MaHS);
            return View(hOCPHI);
        }

        // POST: HOCPHIs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaHocPHi,MaHS,HocPhi1,NgayDong,TinhTrang,GhiChu")] HOCPHI hOCPHI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOCPHI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", hOCPHI.MaHS);
            return View(hOCPHI);
        }

        // GET: HOCPHIs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOCPHI hOCPHI = db.HOCPHIs.Find(id);
            if (hOCPHI == null)
            {
                return HttpNotFound();
            }
            return View(hOCPHI);
        }

        // POST: HOCPHIs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOCPHI hOCPHI = db.HOCPHIs.Find(id);
            db.HOCPHIs.Remove(hOCPHI);
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
