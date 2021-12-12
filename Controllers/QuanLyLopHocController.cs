using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebQuanLyLopHoc_Nhom8.Models;

namespace WebQuanLyLopHoc_Nhom8.Controllers
{
    public class QuanLyLopHocController : Controller
    {
        QLLHModel db = new QLLHModel();
        // GET: QuanLyLopHoc
        public ActionResult Index(string lophoc)
        {
            
            if (!String.IsNullOrEmpty(lophoc))
            {
                var hs = db.HOCSINHs.Where(s => s.LOPHOC.TenLH.Contains(lophoc));
                ViewBag.dshs = hs.ToList();
            }
            else
            {
                lophoc = "Lớp 10A1";
                var hs = db.HOCSINHs.Where(s => s.LOPHOC.TenLH == lophoc);
                ViewBag.dshs = hs.ToList();
            }
            return View();
        }

        public ActionResult LienHePhuHuynh(string mahs)
        {
            int ma = int.Parse(mahs);
            return RedirectToAction("Index", "TTPHUHUYNHHs", new { id = ma });
        }
        public ActionResult TinhTrangHocPhi(string mahs)
        {
            var hp = db.HOCPHIs.Where(s => s.HOCSINH.MaHS == mahs);
            return RedirectToAction("Index", "TTPHUHUYNHHs", new { id = mahs });
        }
    }
}