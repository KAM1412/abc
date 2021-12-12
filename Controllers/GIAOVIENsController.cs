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
    public class GIAOVIENsController : Controller
    {
        private QLLHModel db = new QLLHModel();

        // GET: GIAOVIENs
        public ActionResult Index(string searchStr, int? page)
        {
            var gv = db.GIAOVIENs.Include(g => g.MONHOC);
            if (!String.IsNullOrEmpty(searchStr))
            {
                gv = gv.Where(e => e.TenGV.Contains(searchStr));
            }
            //Sắp xếp trước khi phân trang
            gv = gv.OrderBy(e => e.MaGV);
            int pageSize = 5;
            int pageNumber = (page ?? 1);

            return View(gv.ToPagedList(pageNumber, pageSize));
        }

        // GET: GIAOVIENs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Create
        public ActionResult Create()
        {
            ViewBag.MaMH = new SelectList(db.MONHOCs, "MaMH", "TenMH");
            return View();
        }

        // POST: GIAOVIENs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaGV,TenGV,MaMH,NgaySinh,GioiTinh,QueQuan,SDT,email,HinhAnh")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.GIAOVIENs.Add(gIAOVIEN);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaMH = new SelectList(db.MONHOCs, "MaMH", "TenMH", gIAOVIEN.MaMH);
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaMH = new SelectList(db.MONHOCs, "MaMH", "TenMH", gIAOVIEN.MaMH);
            return View(gIAOVIEN);
        }

        // POST: GIAOVIENs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaGV,TenGV,MaMH,NgaySinh,GioiTinh,QueQuan,SDT,email,HinhAnh")] GIAOVIEN gIAOVIEN)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gIAOVIEN).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaMH = new SelectList(db.MONHOCs, "MaMH", "TenMH", gIAOVIEN.MaMH);
            return View(gIAOVIEN);
        }

        // GET: GIAOVIENs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            if (gIAOVIEN == null)
            {
                return HttpNotFound();
            }
            return View(gIAOVIEN);
        }

        // POST: GIAOVIENs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIAOVIEN gIAOVIEN = db.GIAOVIENs.Find(id);
            db.GIAOVIENs.Remove(gIAOVIEN);
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
