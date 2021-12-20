using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStok.Models.Entity;

namespace MVCStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        MvcDbStokEntities db = new MvcDbStokEntities();
        public ActionResult Index()
        {
            var degerler = db.TBLURUNs.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult Urunekle()
        {
            List<SelectListItem> degerler = (from i in db.TBLKATEGORIs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;

            return View();
        }

        [HttpPost]
        public ActionResult Urunekle(TBLURUN p1)
        {
            var ktgr = db.TBLKATEGORIs.Where(m => m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            p1.TBLKATEGORI = ktgr;
            db.TBLURUNs.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            var urun = db.TBLURUNs.Find(id);
            db.TBLURUNs.Remove(urun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Urungetir(int id)
        {
            var urun = db.TBLURUNs.Find(id);
            List<SelectListItem> degerler = (from i in db.TBLKATEGORIs.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View("Urungetir", urun);
        }
        public ActionResult Guncelle(TBLURUN p1)
        {
            var urn = db.TBLURUNs.Find(p1.URUNID);
            urn.URUNAD = p1.URUNAD;
            urn.MARKA = p1.MARKA;
            urn.STOK = p1.STOK;
            urn.FIYAT = p1.FIYAT;
            //urn.URUNKATEGORI = p1.URUNKATEGORI;
            var ktgr = db.TBLKATEGORIs.Where(m => m.KATEGORIID == p1.TBLKATEGORI.KATEGORIID).FirstOrDefault();
            urn.URUNKATEGORI = ktgr.KATEGORIID;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}