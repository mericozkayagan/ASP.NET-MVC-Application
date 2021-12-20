using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index(string p)            
        {
            var degerler = from d in db.TBLMUSTERIs select d;
            if (!string.IsNullOrEmpty(p))
            {
                degerler = degerler.Where(m => m.MUSTERIAD.Contains(p));
            }
            return View(degerler.ToList());
            //var degerler = db.TBLMUSTERIs.ToList();
            //return View(degerler);
        }
        [HttpGet]
        public ActionResult Yenimusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Yenimusteri(TBLMUSTERI p1)
        {
            if (!ModelState.IsValid)
            {
                return View("Yenimusteri");
            }
            db.TBLMUSTERIs.Add(p1);
            db.SaveChanges();
            return View();
        }
        public ActionResult SIL(int id)
        {
            var mst= db.TBLMUSTERIs.Find(id);
            db.TBLMUSTERIs.Remove(mst);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Musterigetir(int id)
        {
            var mst = db.TBLMUSTERIs.Find(id);
            return View("Musterigetir",mst);
        }
        public ActionResult Guncelle(TBLMUSTERI p2)
        {
            var mst = db.TBLMUSTERIs.Find(p2.MUSTERIID);
            mst.MUSTERIAD = p2.MUSTERIAD;
            mst.MUSTERISOYAD = p2.MUSTERISOYAD;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}