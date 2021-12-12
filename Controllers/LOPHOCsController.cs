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
    public class LOPHOCsController : Controller
    {
        private QLLHModel db = new QLLHModel();

        // GET: LOPHOCs
        public ActionResult Index(string searchStr, int? page)
        {
            var lh = db.LOPHOCs.Include(l => l.GIAOVIEN).Include(l => l.KHOI);
            if (!String.IsNullOrEmpty(searchStr))
            {
                lh = lh.Where(e => e.TenLH.Contains(searchStr));
            }

            lh = lh.OrderBy(e => e.TenLH);
            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(lh.ToPagedList(pageNumber, pageSize));
        }

        // GET: LOPHOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOPHOC lOPHOC = db.LOPHOCs.Find(id);
            if (lOPHOC == null)
            {
                return HttpNotFound();
            }
            return View(lOPHOC);
        }

        // GET: LOPHOCs/Create
        public ActionResult Create()
        {
            ViewBag.MaGVCHUNHIEM = new SelectList(db.GIAOVIENs, "MaGV", "TenGV");
            ViewBag.MaKhoi = new SelectList(db.KHOIs, "MaKhoi", "TenKhoi");
            return View();
        }

        // POST: LOPHOCs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaLH,TenLH,MaKhoi,MaGVCHUNHIEM")] LOPHOC lOPHOC)
        {
            if (ModelState.IsValid)
            {
                db.LOPHOCs.Add(lOPHOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaGVCHUNHIEM = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", lOPHOC.MaGVCHUNHIEM);
            ViewBag.MaKhoi = new SelectList(db.KHOIs, "MaKhoi", "TenKhoi", lOPHOC.MaKhoi);
            return View(lOPHOC);
        }

        // GET: LOPHOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOPHOC lOPHOC = db.LOPHOCs.Find(id);
            if (lOPHOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaGVCHUNHIEM = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", lOPHOC.MaGVCHUNHIEM);
            ViewBag.MaKhoi = new SelectList(db.KHOIs, "MaKhoi", "TenKhoi", lOPHOC.MaKhoi);
            return View(lOPHOC);
        }

        // POST: LOPHOCs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaLH,TenLH,MaKhoi,MaGVCHUNHIEM")] LOPHOC lOPHOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lOPHOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaGVCHUNHIEM = new SelectList(db.GIAOVIENs, "MaGV", "TenGV", lOPHOC.MaGVCHUNHIEM);
            ViewBag.MaKhoi = new SelectList(db.KHOIs, "MaKhoi", "TenKhoi", lOPHOC.MaKhoi);
            return View(lOPHOC);
        }

        // GET: LOPHOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LOPHOC lOPHOC = db.LOPHOCs.Find(id);
            if (lOPHOC == null)
            {
                return HttpNotFound();
            }
            return View(lOPHOC);
        }

        // POST: LOPHOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LOPHOC lOPHOC = db.LOPHOCs.Find(id);
            db.LOPHOCs.Remove(lOPHOC);
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
