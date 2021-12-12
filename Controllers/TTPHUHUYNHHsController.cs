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
    public class TTPHUHUYNHHsController : Controller
    {
        private QLLHModel db = new QLLHModel();

        // GET: TTPHUHUYNHHs
        public ActionResult Index(int id)
        {
            var ph = db.TTPHUHUYNHHS.Include(t => t.HOCSINH);
            ph = db.TTPHUHUYNHHS.Where(e => e.MaPH == id);
            if(ph != null)
            {
                return View(ph.ToList());
            }
            else
            {
                return RedirectToAction("Create", "TTPHUHUYNH", id);
            }
            
        }

        // GET: TTPHUHUYNHHs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTPHUHUYNHH tTPHUHUYNHH = db.TTPHUHUYNHHS.Find(id);
            if (tTPHUHUYNHH == null)
            {
                return HttpNotFound();
            }
            return View(tTPHUHUYNHH);
        }

        // GET: TTPHUHUYNHHs/Create
        public ActionResult Create()
        {
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS");
            return View();
        }

        // POST: TTPHUHUYNHHs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaPH,MaHS,TenPhuHuynh,SDT,email")] TTPHUHUYNHH tTPHUHUYNHH)
        {
            if (ModelState.IsValid)
            {
                db.TTPHUHUYNHHS.Add(tTPHUHUYNHH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", tTPHUHUYNHH.MaHS);
            return View(tTPHUHUYNHH);
        }

        // GET: TTPHUHUYNHHs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTPHUHUYNHH tTPHUHUYNHH = db.TTPHUHUYNHHS.Find(id);
            if (tTPHUHUYNHH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", tTPHUHUYNHH.MaHS);
            return View(tTPHUHUYNHH);
        }

        // POST: TTPHUHUYNHHs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaPH,MaHS,TenPhuHuynh,SDT,email")] TTPHUHUYNHH tTPHUHUYNHH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tTPHUHUYNHH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHS = new SelectList(db.HOCSINHs, "MaHS", "TenHS", tTPHUHUYNHH.MaHS);
            return View(tTPHUHUYNHH);
        }

        // GET: TTPHUHUYNHHs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TTPHUHUYNHH tTPHUHUYNHH = db.TTPHUHUYNHHS.Find(id);
            if (tTPHUHUYNHH == null)
            {
                return HttpNotFound();
            }
            return View(tTPHUHUYNHH);
        }

        // POST: TTPHUHUYNHHs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TTPHUHUYNHH tTPHUHUYNHH = db.TTPHUHUYNHHS.Find(id);
            db.TTPHUHUYNHHS.Remove(tTPHUHUYNHH);
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
